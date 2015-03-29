using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DI_UoW.Model.Entities;

namespace DI_UoW.Service.UserService
{
    public interface IUserService
    {
        Task<ApplicationUser> FindAsync(string userName, string password);
        Task<ClaimsIdentity> SignInAsync(ApplicationUser user);
        Task InsertAsync(ApplicationUser user, string password);
        Task<ApplicationUser> Update(ApplicationUser user);
        //Task<ApplicationUser> GetByIdAsync(string id);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        //Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> where);
        //Task<IEnumerable<ApplicationUser>> GetManyAsync(Expression<Func<ApplicationUser, bool>> where);
        //Task<int> InsertAsync(ApplicationUser entity);
        //Task<int> UpdateAsync(ApplicationUser entity);
        //Task<int> DeleteAsync(ApplicationUser entity);
        //Task<int> DeleteAsync(int id);
        //Task<int> DeleteAsync(Expression<Func<ApplicationUser, bool>> where);
    }
}
