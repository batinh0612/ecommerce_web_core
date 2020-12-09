using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<List<string>> GetAllRolesString();
    }
}
