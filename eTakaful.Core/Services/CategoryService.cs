using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Infrastructure.ViewModel.Category;

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
        public async Task<List<CategoryViewModel>> GetListCategories(string languageId)
        {
            return await _categoryRepository.GetListCategories(languageId);
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
    }
}
