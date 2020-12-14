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
        /// Delete cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCart(Guid id);

        /// <summary>
        /// Get all cart
        /// </summary>
        /// <returns></returns>
        Task<List<CartDetailViewModel>> GetAllProductCart(Guid UserId);

        /// <summary>
        /// Get list cart
        /// </summary>
        /// <returns></returns>
        Task<List<CartViewModel>> GetListCart();

        /// <summary>
        /// GetListCartDetailById
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<List<CartDetail>> GetListCartDetailById(Guid cartId);

        /// <summary>
        /// GetListCartDetailViewModelById
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<List<CartDetailViewModel>> GetListCartDetailViewModelById(Guid cartId);
    }
}
