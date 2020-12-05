using Ecommerce.WebAPI.Infrastructure.Wrappers;
using System;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface IProductApiClient
    {
        /// <summary>
        /// Featured Product Home Page
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<ApiResponse> FeaturedProductHomePage(int take);

        /// <summary>
        /// Latest products
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> LatestProducts();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse> GetById(Guid id);
    }
}
