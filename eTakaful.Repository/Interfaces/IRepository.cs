using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    /// <summary>
    /// Định nghĩa ra các hàm dùng chung thao tác với database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        #region normal function
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> match);

        /// <summary>
        /// FindAll
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        /// <summary>
        /// GetAllIncluding
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// GetFirstOrDefault
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                            IOrderedEnumerable<T>> orderBy = null,
                            Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// AddMany
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool AddMany(IEnumerable<T> entities);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        void Update(T entity, bool isSave);

        /// <summary>
        /// UpdateRange
        /// </summary>
        /// <param name="entity"></param>
        void UpdateRange(List<T> entity);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        void Delete(T entity, bool isSave);

        /// <summary>
        /// DeleteRange
        /// </summary>
        /// <param name="entity"></param>
        void DeleteRange(List<T> entity);
        #endregion



        #region Async function


        /// <summary>
        /// FindAllAsync
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> GetAllAsync();

        /// <summary>
        /// GetFirstOrDefaultAsync
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        T GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                IOrderedQueryable<T>> orderBy = null,
                                Func<IQueryable<T>, IIncludableQueryable<T, Object>> include = null);

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// AddManyAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> AddManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);


        /// <summary>
        /// UpdateRangeAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateRangeAsync(List<T> entity);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(List<T> entity);
        #endregion
    }
}