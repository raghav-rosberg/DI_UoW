using DI_UoW.Model.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_UoW.Data.Repositories.Role
{
    public interface IRoleRepository
    {
        Task<IdentityResult> InsertAsync(ApplicationRole role);
        Task<ApplicationRole> Update(ApplicationRole role);
        Task<IEnumerable<ApplicationRole>> GetAllAsync();
    }
}
