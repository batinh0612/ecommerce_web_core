using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.ViewModels;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Infrastructure.Dto.Common;
using EcommerceCommon.Infrastructure.ViewModel.Category;

namespace Ecommerce.Service.Interface
{
    public interface ICategoryService : IServices<Category>
    {
        /// <summary>
        /// Get category parrent
        /// </summary>
        /// <returns></returns>
        Task<ICollection<CategoryVM>> GetCategoryParrent();

        /// <summary>
        /// Get category for home page
        /// </summary>
        /// <returns></returns>
        Task<CategoryVM> GetCategoryForHomepage();

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryListItem>> GetAllCategories(string languageId);

        /// <summary>
        /// Get list categories
        /// </summary>
        /// <returns></returns>
        List<CategoryViewModel> GetListCategories(string languageId);

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryViewModel> GetCategoryById(Guid id);

        /// <summary>
        /// Create category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> Create(CategoryCreateDto dto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<int> Update(CategoryUpdateDto dto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ChangeStatus(Guid id);

        /// <summary>
        /// Search And Paging Category
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public Task<QueryListResponse<CategoryViewModel>> SearchAndPagingCategory(QueryBase<BaseSearch> dto, string languageId);
    }
}
