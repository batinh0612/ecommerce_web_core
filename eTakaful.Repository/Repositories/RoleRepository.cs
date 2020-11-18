using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public Role Add(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddAsync(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public bool AddMany(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddManyAsync(IEnumerable<Role> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Role> entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<Role> entity)
        {
            throw new NotImplementedException();
        }

        public Role Find(Expression<Func<Role, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<Role> FindAll(Expression<Func<Role, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Role>> FindAllAsync(Expression<Func<Role, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindAsync(Expression<Func<Role, bool>> match)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> GetAllIncluding(params Expression<Func<Role, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Role GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Role GetFirstOrDefault(Expression<Func<Role, bool>> predicate, Func<IQueryable<Role>, IOrderedEnumerable<Role>> orderBy = null, Func<IQueryable<Role>, IIncludableQueryable<Role, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public Role GetFirstOrDefaultAsync(Expression<Func<Role, bool>> predicate, Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null, Func<IQueryable<Role>, IIncludableQueryable<Role, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role entity, bool isSave)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<Role> entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(List<Role> entity)
        {
            throw new NotImplementedException();
        }
    }
}
