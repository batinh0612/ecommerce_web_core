using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface ICartApiClient
    {
        /// <summary>
        /// Get all cart
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> GetAllCart();

        /// <summary>
        /// Add cart
        /// </summary>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        Task<ApiResponse> AddCart(CartDto cartDto);
    }
}
