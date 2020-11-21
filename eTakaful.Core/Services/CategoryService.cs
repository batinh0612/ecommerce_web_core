using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Infrastructure.Dto.Common;
using EcommerceCommon.Infrastructure.Extensions;
using EcommerceCommon.Infrastructure.ViewModel.Category;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Services
{
    public class CategoryService : EcommerceServices<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;        
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;           
            _mapper = mapper;
        }

        /// <summary>
        /// Change statuss
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ChangeStatus(Guid id)
        {
            return await _categoryRepository.ChangeStatus(id);
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> Create(CategoryCreateDto dto)
        {
            return await _categoryRepository.Create(dto);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            return await _categoryRepository.Delete(id);
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryListItem>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        /// <summary>
        /// Get category for home page
        /// </summary>
        /// <returns></returns>
        public Task<CategoryVM> GetCategoryForHomepage()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get category parrent
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<CategoryVM>> GetCategoryParrent()
        {
            var category = await _categoryRepository.GetCategoryParrent();
            return _mapper.Map<List<CategoryVM>>(category);
        }

        /// <summary>
        /// Get list categories
        /// </summary>
        /// <returns></returns>
        public List<CategoryViewModel> GetListCategories(string languageId)
        {
            return _categoryRepository.GetListCategories(languageId).ToList();

        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> Update(CategoryUpdateDto dto)
        {
            return await _categoryRepository.Update(dto);
        }

        public async Task<QueryListResponse<CategoryViewModel>> SearchAndPagingCategory(QueryBase<BaseSearch> dto, string languageId)
        {
            return new QueryListResponse<CategoryViewModel>
            {
                Count = await BuildActivityQueryable(dto, languageId).CountAsync(),
                Items = await FilterActivities(dto, languageId)
            };
        }

        #region Private method
        private IQueryable<CategoryViewModel> BuildActivityQueryable(QueryBase<BaseSearch> search, string languageId)
        {
            var query = _categoryRepository.GetListCategories(languageId).Where(x => x.IsDeleted == false);

            if (!string.IsNullOrEmpty(search.Filter.Search))
            {
                query = query.Where(x => x.Name.Contains(search.Filter.Search));
            }

            return query;
        }

        private async Task<List<CategoryViewModel>> FilterActivities(QueryBase<BaseSearch> search, string languageId)
        {
            var query = BuildActivityQueryable(search, languageId);
            var orderBy = string.IsNullOrEmpty(search.OrderBy) ? "CreatedDate" : search.OrderBy;

            query = EntityQueryFilterHelper.CreateSort<CategoryViewModel>(search.Direction ==  SortType.Desc, orderBy)(query);
            query = EntityQueryFilterHelper.Page<CategoryViewModel>(search.PageIndex, search.PageSize)(query);
            return await query.ToListAsync();
        }
        #endregion
    }
}
