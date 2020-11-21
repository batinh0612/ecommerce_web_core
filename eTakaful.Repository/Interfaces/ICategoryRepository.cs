using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Infrastructure.ViewModel.Category;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {

        /// <summary>
        /// Get all as queryable
        /// </summary>
        /// <returns></returns>
        IQueryable<CategoryViewModel> GetAllAsQueryale();

        /// <summary>
        /// Get category parrent
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Category>> GetCategoryParrent();

       /// <summary>
       /// Get all
       /// </summary>
       /// <returns></returns>
       Task<List<CategoryListItem>> GetAllCategories();

       /// <summary>
       /// Get list categories
       /// </summary>
       /// <returns></returns>
       IQueryable<CategoryViewModel> GetListCategories(string languageId);

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
    }
}
