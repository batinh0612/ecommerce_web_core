using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Ecommerce.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext DbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Normal function
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(Guid id)
        {
            return DbContext.Set<T>().Find(id);

        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            //DbContext.Set<T>().Add(entity);

            //if (isSave)
            //{
            //    DbContext.SaveChanges();
            //}

            //return entity;

            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        public virtual void Update(T entity, bool isSave = true)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            if (isSave)
            {
                DbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        public virtual void Delete(T entity, bool isSave = true)
        {
            DbContext.Set<T>().Remove(entity);
            if (isSave)
            {
                DbContext.SaveChanges();
            }

        }

        /// <summary>
        /// AddMany
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool AddMany(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
            DbContext.SaveChanges();

            return true;
        }

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbContext.Set<T>().Where(predicate);
            return query;
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> match)
        {
            return DbContext.Set<T>().SingleOrDefault(match);
        }

        /// <summary>
        /// FindAll
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return DbContext.Set<T>().Where(match).ToList();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(Guid id)
        {
            return DbContext.Set<T>().Find(id);
        }

        /// <summary>
        /// GetAllIncluding
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        /// <summary>
        /// UpdateRange
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateRange(List<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);
            DbContext.SaveChanges();
        }

        /// <summary>
        /// DeleteRange
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(List<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// GetFirstOrDefault
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Async function       
        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult<IQueryable<T>>(DbContext.Set<T>());
        }

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// AddManyAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddManyAsync(IEnumerable<T> entities)
        {
            await DbContext.Set<T>().AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// FindAllAsync
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().Where(match).ToListAsync();
        }

        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        /// <summary>
        /// GetFirstOrDefaultAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            try
            {
                IQueryable<T> query = DbContext.Set<T>().AsNoTracking();

                if (include != null) query = include(query);

                query = query.Where(predicate);

                if (orderBy != null) query = orderBy(query);

                return query.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        //public virtual async Task UpdateAsync(T entity, bool isSave = true)
        //{
        //    DbContext.Entry(entity).State = EntityState.Modified;
        //    if (isSave)
        //    {
        //        await DbContext.SaveChangesAsync();
        //    }

        //}

        /// <summary>
        /// UpdateRangeAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(List<T> entities)
        {
            DbContext.Set<T>().UpdateRange(entities);

            await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            //if (isSave)
            //{
            //    await DbContext.SaveChangesAsync();
            //}

            await DbContext.SaveChangesAsync();

        }

        /// <summary>
        /// DeleteRangeAsync
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task DeleteRangeAsync(List<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }
        #endregion
    }

}