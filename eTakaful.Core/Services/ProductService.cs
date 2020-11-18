using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;
using EcommerceCommon.Infrastructure.Dto.Product;
using EcommerceCommon.Infrastructure.ViewModel.Product;

namespace Ecommerce.Service.Services
{
    public class ProductService : EcommerceServices<Product>, IProductSevice
    {
        private readonly IProductRepository _productReponsitory;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productReponsitory, IMapper mapper) : base(productReponsitory)
        {
            _productReponsitory = productReponsitory;
            _mapper = mapper;
            _productReponsitory = productReponsitory;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> Create(ProductCreateDto dto)
        {
            return await _productReponsitory.Create(dto);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            return await _productReponsitory.Delete(id);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetAllProducts(string languageId, Guid? categoryId)
        {
            return await _productReponsitory.GetAllProducts(languageId, categoryId);
        }

        public Task<ProductViewModel> GetDiscountProduct()
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetHotTrendProduct()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetProductByCategoryIdAndOrderByView(Guid categoryId)
        {
            var product = await _productReponsitory.GetProductByCategoryIdAndOrderByView(categoryId);
            return _mapper.Map<List<ProductViewModel>>(product);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            return await _productReponsitory.GetProductById(id);
        }

        public async Task<bool> GrowUpViewByProductId(Guid productId)
        {
            return await _productReponsitory.GrowUpViewByProductId(productId);
        }

        /// <summary>
        /// New product
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> NewProduct()
        {
            return await _productReponsitory.GetNewProduct();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> Update(ProductUpdateDto dto)
        {
            return await _productReponsitory.Update(dto);
        }
    }
}
