using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Common;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Dto.Product;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using EcommerceCommon.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IStorageRepository _storageRepository;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductRepository(ApplicationDbContext dbContext, IStorageRepository storageRepository) : base(dbContext)
        {
            _storageRepository = storageRepository;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> Create(ProductCreateDto dto)
        {
            var product = new Product()
            {
                Code = dto.Code,
                PercentDiscount = dto.PercentDiscount,
                Width = dto.Width,
                Height = dto.Height,
                Weight = dto.Weight,
                Views = 0,
                Sku = dto.Sku,
                Quantity = dto.Quantity,
                PublicationDate = dto.PublicationDate,
                ExpirationDate = dto.ExpirationDate,
                Price = dto.Price,
                CommonStatus = Status.Active,
                SupplierId = dto.SupplierId,
                ManufactureId = dto.ManufactureId,
                ProductInCategories = new List<ProductInCategory>()
                {
                    new ProductInCategory()
                    {
                        CategoryId = dto.CategoryId
                    }
                },
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Description = dto.Description,
                        Details = dto.Details,
                        Keyword = dto.Keyword,
                        Name = dto.Name,
                        SeoAlias = dto.SeoAlias,
                        SeoDescription = dto.SeoDescription,
                        SeoTitle = dto.SeoTitle,
                        ShortDescription = dto.ShortDescription,
                        ProductStatus = ProductStatusEnum.New,
                        LanguageId = "vi"
                    }
                }
            };

            if (dto.ThumnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        ImageLink = await this.SaveFile(dto.ThumnailImage),
                        MainImage = true
                    }
                };
            }

            DbContext.Products.Add(product);
            await DbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetAllProducts(string languageId, Guid? categoryId)
        {

            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId into ptt
                        from pt in ptt.DefaultIfEmpty()
                        join pic in DbContext.ProductInCategories on p.Id equals pic.ProductId into picc
                        from pic in picc.DefaultIfEmpty()
                            //join c in DbContext.Categories on pic.CategoryId equals c.Id into cc
                            //from c in cc.DefaultIfEmpty()
                        join s in DbContext.Suppliers on p.SupplierId equals s.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic, s };

            var products = await (query.Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                Code = x.p.Code,
                Description = x.pt.Description,
                Price = x.p.Price,
                Quantity = x.p.Quantity,
                Views = x.p.Views,
                ShortDescription = x.pt.ShortDescription,
                PublicationDate = x.p.PublicationDate,
                PercentDiscount = x.p.PercentDiscount.HasValue ? x.p.PercentDiscount.Value : 0,
                ProductStatus = x.pt.ProductStatus,
                Sku = x.p.Sku,
                Keyword = x.pt.Keyword,
                CategoryId = x.pic.CategoryId,
                LanguageId = languageId
            })).ToListAsync();


            //var reuslt = products;

            if (categoryId != null)
            {
                products = products.Where(x => x.CategoryId == categoryId).ToList();
            }

            return products;
        }

        /// <summary>
        /// Get new product
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetNewProduct()
        {
            DateTime startDateTime;
            DateTime endDateTime;

            startDateTime = DateTime.Today;//Today at 00:00:00
            endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);//Today at 23:59:59

            var query = await (from p in DbContext.Products.Where(x => x.CreatedDate >= startDateTime && x.CreatedDate <= endDateTime)
                               join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId /*into ptt*/
                               //from pt in ptt.DefaultIfEmpty()
                               join s in DbContext.Suppliers on p.SupplierId equals s.Id into ss
                               from s in ss.DefaultIfEmpty()
                               select new ProductViewModel
                               {
                                   Code = string.IsNullOrEmpty(p.Code) ? "" : p.Code,
                                   Name = string.IsNullOrEmpty(pt.Name) ? "" : pt.Name,
                                   Height = p.Height,
                                   Quantity = p.Quantity,
                                   ShortDescription = pt.ShortDescription,
                                   Sku = p.Sku,
                                   Price = p.Price,
                                   SupplierName = string.IsNullOrEmpty(s.Name) ? "" : s.Name,
                                   ProductStatus = pt.ProductStatus,
                                   Views = p.Views,
                                   PublicationDate = p.PublicationDate,
                                   Description = string.IsNullOrEmpty(pt.Description) ? "" : pt.Description
                               }).ToListAsync();
            return query;
        }

        /// <summary>
        /// GetProductByCategoryIdAndOrderByView
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetProductByCategoryIdAndOrderByView(Guid categoryId)
        {

            var products = await DbContext.Products.Where(c => c.Views >= 100).Take(100)
                .ToListAsync();
            return products;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var query = from p in DbContext.Products
                        join pi in DbContext.ProductImages on p.Id equals pi.ProductId
                        join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId into ptt
                        from pt in ptt.DefaultIfEmpty()
                        join pic in DbContext.ProductInCategories on p.Id equals pic.ProductId into picc
                        from pic in picc.DefaultIfEmpty()
                        join s in DbContext.Suppliers on p.SupplierId equals s.Id
                        join m in DbContext.Manufactures on p.ManufactureId equals m.Id
                        where p.Id == id
                        select new { p, pic, s, m, pt, pi };

            var productViewModel = await query.Select(x => new ProductViewModel()
            {
                Code = x.p.Code,
                Description = x.pt.Description,
                ExpirationDate = x.p.ExpirationDate,
                Height = x.p.Height,
                Name = x.pt.Name,
                PercentDiscount = x.p.PercentDiscount,
                Price = x.p.Price,
                Quantity = x.p.Quantity,
                Keyword = x.pt.Keyword,
                Id = x.p.Id,
                ProductStatus = x.pt.ProductStatus,
                PublicationDate = x.p.PublicationDate,
                ShortDescription = x.pt.ShortDescription,
                Sku = x.p.Sku,
                Views = x.p.Views,
                Weight = x.p.Weight,
                Width = x.p.Width,
                Details = x.pt.Details,
                ManufactureName = x.m.Name,
                SupplierName = x.s.Name,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                SeoAlias = x.pt.SeoAlias,
                ImageLink = x.pi.ImageLink
            }).FirstOrDefaultAsync();

            return productViewModel;
        }

        /// <summary>
        /// Get View Product
        /// </summary>
        /// <returns></returns>
        public async Task<List<MostViewProductViewModel>> GetProductView()
        {
            var product = await (
                    from p in DbContext.Products.Where(x => x.IsDeleted == false)/*.OrderByDescending(x => x.Views).Take(5)*/
                    join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId/* into ptt*/
                    //from pt in ptt.DefaultIfEmpty()
                    join pic in DbContext.ProductInCategories on p.Id equals pic.ProductId
                    join c in DbContext.Categories on pic.CategoryId equals c.Id
                    join ct in DbContext.CategoryTranslations on c.Id equals ct.CategoryId
                    join s in DbContext.Suppliers on p.SupplierId equals s.Id
                    orderby p.Views descending
                    select new MostViewProductViewModel
                    {
                        ProductId = p.Id,
                        CategoryName = ct.Name,
                        Price = p.Price,
                        SupplierName = s.Name,
                        Name = pt.Name,
                        Views = p.Views,
                        Code = p.Code,
                        Quantity = p.Quantity
                    }
                ).Take(5).ToListAsync();
            return product;
        }

        /// <summary>
        /// GrowUpViewByProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> GrowUpViewByProductId(Guid productId)
        {
            // get product by id
            var product = await GetByIdAsync(productId);
            if (product != null)
            {
                product.Views = product.Views + 1;
                await UpdateAsync(product);
                return true;
            }

            return false;
        }

        #region Function private
        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageRepository.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        /// <summary>
        /// Remove file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task RemoveFile(string fileName)
        {
            await _storageRepository.DeleteFileAsync(fileName);
        }

        #endregion

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> Update(ProductUpdateDto dto)
        {
            var product = await DbContext.Products.FindAsync(dto.Id);
            var productTranslation = await DbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == dto.Id);

            if (product == null || productTranslation == null)
            {
                throw new EcommerceException($"Cannot find product with id: {dto.Id}");
            }

            productTranslation.Details = dto.Details;
            productTranslation.Description = dto.Description;
            productTranslation.Keyword = dto.Keyword;
            productTranslation.Name = dto.Name;
            productTranslation.ShortDescription = dto.ShortDescription;
            productTranslation.ProductStatus = dto.ProductStatus;
            productTranslation.SeoDescription = dto.SeoDescription;
            productTranslation.SeoTitle = dto.SeoTitle;
            productTranslation.SeoAlias = dto.SeoAlias;

            if (dto.ThumbnailImage != null)
            {
                var thumbnailImage = await DbContext.ProductImages.FirstOrDefaultAsync(x => x.MainImage == true && x.ProductId == dto.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = dto.ThumbnailImage.Length;
                    thumbnailImage.ImageLink = await this.SaveFile(dto.ThumbnailImage);
                    DbContext.ProductImages.Update(thumbnailImage);
                }
            }

            DbContext.ProductTranslations.Update(productTranslation);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            var product = await DbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new EcommerceException($"Cannot find product with id: {id}");
            }
            var productImages = await DbContext.ProductImages.Where(x => x.ProductId == id).ToListAsync();

            foreach (var item in productImages)
            {
                await _storageRepository.DeleteFileAsync(item.ImageLink);
            }

            try
            {
                DbContext.Products.Remove(product);
            }
            catch (Exception)
            {
                return false;
                throw;
            }

            await DbContext.SaveChangesAsync();
            return true;
        }
    }
}
