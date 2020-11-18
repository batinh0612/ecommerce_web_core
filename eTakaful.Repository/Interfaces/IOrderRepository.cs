using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// Get total order
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalOrder();

        /// <summary>
        /// Get new order
        /// </summary>
        /// <returns></returns>
        Task<List<NewOrderViewModel>> GetNewOrder();
    }
}
