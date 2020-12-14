using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        /// <summary>
        /// Get product cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductSizeId"></param>
        /// <param name="ProductColorId"></param>
        /// <returns></returns>
        Task<ProductCartViewModel> GetProductCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, string LanguageId);

        /// <summary>
        /// Get all product cart
        /// </summary>
        /// <returns></returns>
        Task<List<CartDetailViewModel>> GetAllProductCart(Guid UserId);

        /// <summary>
        /// Get List Cart Detail By Id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<List<CartDetail>> GetListCartDetailById(Guid cartId);

        /// <summary>
        /// Get list cart
        /// </summary>
        /// <returns></returns>
        Task<List<CartViewModel>> GetListCart();

        /// <summary>
        /// GetListCartDetailViewModelById
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<List<CartDetailViewModel>> GetListCartDetailViewModelById(Guid cartId);
    }
}
