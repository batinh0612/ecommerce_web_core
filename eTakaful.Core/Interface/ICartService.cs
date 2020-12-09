using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface ICartService : IServices<Cart>
    {
        /// <summary>
        /// Add cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductSizeId"></param>
        /// <param name="ProductColorId"></param>
        /// <param name="Quantity"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<bool> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId, string LanguageId);

        /// <summary>
        /// Get all cart
        /// </summary>
        /// <returns></returns>
        Task<List<CartViewModel>> GetAllProductCart();
    }
}
