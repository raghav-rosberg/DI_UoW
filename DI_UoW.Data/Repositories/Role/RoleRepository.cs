using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DI_UoW.Data.DbContext;
using DI_UoW.Model.Entities;
using System.Data.Entity.Validation;

namespace DI_UoW.Data.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        readonly RoleManager<ApplicationRole> m_roleManager;
        public RoleRepository()
        {
            m_roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new DI_UoW_DbContext()));
        }
        
        public async Task<IdentityResult> InsertAsync(ApplicationRole role)
        {
            return await m_roleManager.CreateAsync(role);
        }

        public async Task<ApplicationRole> Update(ApplicationRole role)
        {
            await m_roleManager.UpdateAsync(role);
            return role;
        }

        public async Task<IEnumerable<ApplicationRole>> GetAllAsync()
        {
            return await m_roleManager.Roles.ToListAsync();
        }
    }
}
