using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DI_UoW.Data.DbContext;
using DI_UoW.Model.Entities;
using System.Data.Entity.Validation;

namespace DI_UoW.Data.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        readonly UserManager<ApplicationUser> m_userManager;
        public UserRepository()
        {
            m_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DI_UoW_DbContext()));
        }

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await m_userManager.FindAsync(userName, password);
        }

        public async Task<ClaimsIdentity> SignInAsync(ApplicationUser user)
        {
            return await m_userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public async Task InsertAsync(ApplicationUser user, string password)
        {
            await m_userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            await m_userManager.UpdateAsync(user);
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await m_userManager.Users.ToListAsync();
        }
    }
}
