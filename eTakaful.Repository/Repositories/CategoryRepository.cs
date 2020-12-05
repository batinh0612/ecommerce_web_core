using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using EcommerceCommon.Infrastructure.Dto.Category;
using EcommerceCommon.Infrastructure.ViewModel.Category;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Get all as queryable
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<CategoryViewModel> GetAllAsQueryale()
        {
            throw new Exception();
        }

        /// <summary>
        /// Get category parrent
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Category>> GetCategoryParrent()
        {
            return await DbContext.Categories.Where(c => c.ParentId == null).ToListAsync();
        }

        /// <summary>
        /// Get by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<Category>().FindAsync(id);
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryListItem>> GetAllCategories(string languageId)
        {
            var categories = await (from c in DbContext.Categories
                                   join ct in DbContext.CategoryTranslations on c.Id equals ct.CategoryId
                                   where ct.LanguageId == languageId
                                   select new CategoryListItem()
                                   {
                                       Id = c.Id,
                                       Name = ct.Name
                                   }).ToListAsync();

            return categories;
        }

        /// <summary>
        /// Get list categories
        /// </summary>
        /// <returns></returns>
        public IQueryable<CategoryViewModel> GetListCategories(string languageId)
        {
            var categories =  (from c in DbContext.Categories
                                    join ct in DbContext.CategoryTranslations on c.Id equals ct.CategoryId
                                    where ct.LanguageId == languageId
                                    select new CategoryViewModel()
                                    {
                                        Id = c.Id,
                                        Description = ct.Description,
                                        IsDisplayHomePage = c.IsDisplayHomePage,
                                        MetaTitle = ct.MetaTitle,
                                        Name = ct.Name,
                                        ParentId = c.ParentId,
                                        CreatedDate = c.CreatedDate,
                                        LanguageId = languageId,
                                        IsDeleted = c.IsDeleted
                                    });

            return categories;
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            var query = await DbContext.Categories.FindAsync(id);

            var categoryTranslation = await DbContext.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == id);

            Category parentName = new Category();
            if (query.ParentId != null)
            {
                 parentName = DbContext.Categories.Find(query.ParentId);
            }

            var category = new CategoryViewModel()
            {
                CreatedDate = query.CreatedDate,
                Description = categoryTranslation.Description,
                Id = query.Id,
                IsDisplayHomePage = query.IsDisplayHomePage,
                MetaTitle = categoryTranslation.MetaTitle,
                Name = categoryTranslation.Name,
                ParentId = query.ParentId,
                CommonStatus = query.CommonStatus,
                CategoryName = string.IsNullOrEmpty(categoryTranslation.Name) ? "Không có" : categoryTranslation.Name
            };

            return category;
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Create(CategoryCreateDto dto)
        {
            var category = new Category()
            {
                IsDisplayHomePage = dto.IsDisplayHomePage,
                ParentId = dto.ParentId,
                CategoryTranslations =  new List<CategoryTranslation>()
                {
                    new CategoryTranslation()
                    {
                        Name = dto.Name,
                        Description = dto.Description,
                        MetaTitle = dto.MetaTitle,
                        LanguageId = "vi"
                    }
                }
            };

            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<int> Update(CategoryUpdateDto dto)
        {
            var category = await DbContext.Categories.FindAsync(dto.Id);
            var translation = await DbContext.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == category.Id);

            category.ParentId = dto.ParentId;
            category.UpdatedDate = DateTime.Now;
            translation.Name = dto.Name;
            translation.Description = dto.Description;
            translation.MetaTitle = dto.MetaTitle;

            DbContext.Categories.Update(category);
            DbContext.CategoryTranslations.Update(translation);

            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Change status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> ChangeStatus(Guid id)
        {
            var category = await DbContext.Categories.FindAsync(id);

            category.IsDisplayHomePage = !category.IsDisplayHomePage;
            await DbContext.SaveChangesAsync();

            return category.IsDisplayHomePage;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id)
        {
            var category = await DbContext.Categories.FindAsync(id);

            if (category != null)
            {
                DbContext.Categories.Remove(category);
                await DbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
