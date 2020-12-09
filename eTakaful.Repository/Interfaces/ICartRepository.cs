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
        Task<List<CartViewModel>> GetAllProductCart();
    }
}
