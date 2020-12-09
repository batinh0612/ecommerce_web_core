using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Get product cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductSizeId"></param>
        /// <param name="ProductColorId"></param>
        /// <returns></returns>
        public async Task<ProductCartViewModel> GetProductCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, string LanguageId)
        {
            var productCart = await (from p in DbContext.Products
                              join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId
                              join pa in DbContext.ProductAttributes on p.Id equals pa.ProductId
                              join pc in DbContext.ProductColors on pa.ProductColorId equals pc.Id into pcl
                              from pc in pcl.DefaultIfEmpty()
                              join ps in DbContext.ProductSizes on pa.ProductSizeId equals ps.Id into psl
                              from ps in psl.DefaultIfEmpty()
                              join pi in DbContext.ProductImages on p.Id equals pi.ProductId
                              join s in DbContext.Suppliers on p.SupplierId equals s.Id
                              where p.IsDeleted == false && pa.ProductSizeId == ProductSizeId && pa.ProductColorId == ProductColorId
                              && pi.MainImage == true && pt.LanguageId == LanguageId
                              select new ProductCartViewModel
                              {
                                  Id = pa.Id,
                                  Name = pt.Name,
                                  ImageLink = pi.ImageLink,
                                  Price = p.Price,
                                  PercentDiscount = p.PercentDiscount.HasValue ? p.PercentDiscount.Value : 0,
                                  Size = ps.Name,
                                  Color = pc.Name,
                                  CountStock = pa.CountStock,
                                  SupplierName = s.Name
                              }).FirstOrDefaultAsync();

            return productCart;
        }

        /// <summary>
        /// Get all product cart
        /// </summary>
        /// <returns></returns>
        public async Task<List<CartViewModel>> GetAllProductCart()
        {
            var carts = await (from c in DbContext.Carts
                               join cd in DbContext.CartDetails on c.Id equals cd.CartId
                               join p in DbContext.Products on cd.ProductId equals p.Id
                               join pt in DbContext.ProductTranslations on p.Id equals pt.ProductId
                               join pi in DbContext.ProductImages on pt.ProductId equals pi.ProductId
                               where pi.MainImage == true && p.IsDeleted == false && pt.LanguageId == "vi" &&
                               c.CartStatus == Domain.Enums.ShoppingCartEnum.PreOrder
                               select new CartViewModel
                               {
                                   Id = c.Id,
                                   Quantity = cd.Quantity,
                                   ImageLink = pi.ImageLink,
                                   Name = pt.Name,
                                   Price = cd.Price,
                                   TotalPrice = cd.Quantity * cd.Price
                               }).ToListAsync();

            return carts;
        }
    }
}
