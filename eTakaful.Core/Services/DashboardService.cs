using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ViewModel;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        public DashboardService(IProductRepository productRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get new order
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewOrderViewModel>> GetNewOrder()
        {
            return await _orderRepository.GetNewOrder();
        }

        /// <summary>
        /// Get new product in date
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetNewProduct()
        {
            return await _productRepository.GetNewProduct();
        }

        /// <summary>
        /// Get product view
        /// </summary>
        /// <returns></returns>
        public async Task<List<MostViewProductViewModel>> GetProductView(string languageId)
        {
            return await _productRepository.GetProductView(languageId);
        }

        /// <summary>
        /// Get total order
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalOrder()
        {
            return await _orderRepository.GetTotalOrder();
        }

        /// <summary>
        /// Get user register
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewUserRegisterViewModel>> GetUserRegisters()
        {
            return await _userRepository.GetUserRegister();
        }

        /// <summary>
        /// Total income system
        /// </summary>
        /// <returns></returns>
        public Task<decimal> TotalIncomeSystem()
        {
            throw new NotImplementedException();
        }
    }
}
