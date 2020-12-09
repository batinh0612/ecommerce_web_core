using Ecommerce.Service.Dto;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface IDashboardService
    {
        /// <summary>
        /// Get total order
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalOrder();

        /// <summary>
        /// Get user register
        /// </summary>
        /// <returns></returns>
        Task<List<NewUserRegisterViewModel>> GetUserRegisters();

        /// <summary>
        /// Get new product
        /// </summary>
        /// <returns></returns>
        Task<List<ProductViewModel>> GetNewProduct(string languageId);

        /// <summary>
        /// Total income system
        /// </summary>
        /// <returns></returns>
        Task<decimal> TotalIncomeSystem();

        /// <summary>
        /// Get product view
        /// </summary>
        /// <returns></returns>
        Task<List<MostViewProductViewModel>> GetProductView(string languageId);

        /// <summary>
        /// Get new order
        /// </summary>
        /// <returns></returns>
        Task<List<NewOrderViewModel>> GetNewOrder();
    }
}
