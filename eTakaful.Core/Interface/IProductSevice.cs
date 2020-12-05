using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.Product;
using EcommerceCommon.Infrastructure.ViewModel.Product;

namespace Ecommerce.Service.Interface
{
    public  interface IProductSevice : IServices<Product>
    {
        #region Admin
        Task<List<ProductViewModel>> GetProductByCategoryIdAndOrderByView(Guid categoryId);

        Task<bool> GrowUpViewByProductId(Guid productId);

        // Lấy ra những sản phẩm hot trend (Lượt xem nhiều nhất và số lượng mua nhiều nhất)
        Task<ProductViewModel> GetHotTrendProduct();

        // Lấy ra những sản phẩm đang được giảm giá nhiếu nhất
        Task<ProductViewModel> GetDiscountProduct();

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
        /// New products
        /// </summary>
        /// <returns></returns>
        Task<List<ProductViewModel>> NewProduct();

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        Task<bool> Create(ProductCreateDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> Update(ProductUpdateDto dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
        #endregion


        #region Home page
        /// <summary>
        /// New product home page
        /// </summary>
        /// <returns></returns>
        Task<List<ProductHomePageViewModel>> NewProductHomePage();

        /// <summary>
        /// Featured Product Home Page
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<List<ProductHomePageViewModel>> FeaturedProductHomePage(int take);
        #endregion
    }
}
