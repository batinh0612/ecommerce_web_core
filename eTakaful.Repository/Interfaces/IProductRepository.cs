using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.Product;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.Product;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        #region Admin
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Create(ProductCreateDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> Update(ProductUpdateDto dto);

        /// <summary>
        /// GetProductByCategoryIdAndOrderByView
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<Product>> GetProductByCategoryIdAndOrderByView(Guid categoryId);

        /// <summary>
        /// GrowUpViewByProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> GrowUpViewByProductId(Guid productId);

        /// <summary>
        /// Get Product View
        /// </summary>
        /// <returns></returns>
        Task<List<MostViewProductViewModel>> GetProductView();

        /// <summary>
        /// Get new product
        /// </summary>
        /// <returns></returns>
        Task<List<ProductViewModel>> GetNewProduct();

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        Task<List<ProductViewModel>> GetAllProducts(string languageId, Guid? categoryId);

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductViewModel> GetProductById(Guid id);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
        #endregion

        #region Home page
        Task<List<ProductHomePageViewModel>> NewProductHomePage();
        #endregion
    }

}
