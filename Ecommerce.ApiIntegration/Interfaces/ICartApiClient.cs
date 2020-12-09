using Ecommerce.WebAPI.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface ICartApiClient
    {
        /// <summary>
        /// Add cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductSizeId"></param>
        /// <param name="ProductColorId"></param>
        /// <param name="Quantity"></param>
        /// <param name="UserId"></param>
        /// <param name="LanguageId"></param>
        /// <returns></returns>
        Task<ApiResponse> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId, string LanguageId);
    }
}
