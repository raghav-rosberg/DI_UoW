using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DI_UoW.Model.Entities;

namespace DI_UoW.Data.Repositories.User
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindAsync(string userName, string password);
        Task<ClaimsIdentity> SignInAsync(ApplicationUser user);
        Task InsertAsync(ApplicationUser user, string password);
        Task<ApplicationUser> Update(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
