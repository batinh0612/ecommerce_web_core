using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Get New Order
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewOrderViewModel>> GetNewOrder()
        {
            var startDateTime = DateTime.Today;
            var endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            var query = from o in DbContext.Orders.Where(x => x.CreatedDate >= startDateTime && x.CreatedDate <= endDateTime)
                        join c in DbContext.Customers on o.CustomerId equals c.Id
                        select new NewOrderViewModel
                        {
                            OrderId = o.Id,
                            OrderNumber = o.OrderNumber,
                            CreateDate = o.CreatedDate,
                            OrderStatus = o.OrderStatus,
                            TotalPrice = o.TotalPrice,
                            CustomerName = c.Name,
                            Address = o.Address,
                            Discount = o.Discount,
                            FeeMount = o.FeeMount,
                            PaymentType = o.PaymentType,
                            Phone = o.Phone,
                            VoucherCode = o.VoucherCode
                        };
            return await query.ToListAsync();
        }

        /// <summary>
        /// Get Total Order
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalOrder()
        {
            var startDateTime = DateTime.Today;
            var endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            var result = await DbContext.Orders.Where(x => x.CreatedDate >= startDateTime && x.CreatedDate <= endDateTime).CountAsync();
            return result;
        }
    }
}
