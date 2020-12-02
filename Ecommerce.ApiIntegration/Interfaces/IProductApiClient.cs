using Ecommerce.WebAPI.Infrastructure.Wrappers;
using System.Threading.Tasks;

namespace Ecommerce.ApiIntegration.Interfaces
{
    public interface IProductApiClient
    {
        /// <summary>
        /// New product home page
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse> NewProductHomePage();
    }
}
