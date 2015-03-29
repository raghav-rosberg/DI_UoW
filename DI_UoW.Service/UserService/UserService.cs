using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DI_UoW.Data.UnitOfWork;
using DI_UoW.Model.Entities;

namespace DI_UoW.Service.UserService
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork m_unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await m_unitOfWork.UserRepository.FindAsync(userName, password);
        }

        public async Task<ClaimsIdentity> SignInAsync(ApplicationUser user)
        {
            return await m_unitOfWork.UserRepository.SignInAsync(user);
        }

        public async Task InsertAsync(ApplicationUser user, string password)
        {
            await m_unitOfWork.UserRepository.InsertAsync(user, password);
        }

        public async Task<ApplicationUser> Update(ApplicationUser user)
        {
            return await m_unitOfWork.UserRepository.Update(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return await m_unitOfWork.UserRepository.GetAllAsync();
        }

        //public async Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> @where)
        //{
        //    return await m_unitOfWork.UserRepository.GetAsync(@where);
        //}

        //public async Task<IEnumerable<ApplicationUser>> GetManyAsync(Expression<Func<ApplicationUser, bool>> @where)
        //{
        //    return await m_unitOfWork.UserRepository.GetManyAsync(@where);
        //}

        //public async Task<int> InsertAsync(ApplicationUser entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    m_unitOfWork.UserRepository.Insert(entity);
        //    return await m_unitOfWork.CommitAsync();
        //}

        //public async Task<int> UpdateAsync(ApplicationUser entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    m_unitOfWork.UserRepository.Update(entity);
        //    return await m_unitOfWork.CommitAsync();
        //}

        //public async Task<int> DeleteAsync(ApplicationUser entity)
        //{
        //    m_unitOfWork.UserRepository.Delete(entity);
        //    return await m_unitOfWork.CommitAsync();
        //}

        //public async Task<int> DeleteAsync(int id)
        //{
        //    m_unitOfWork.UserRepository.Delete(id);
        //    return await m_unitOfWork.CommitAsync();
        //}

        //public async Task<int> DeleteAsync(Expression<Func<ApplicationUser, bool>> @where)
        //{
        //    m_unitOfWork.UserRepository.Delete(@where);
        //    return await m_unitOfWork.CommitAsync();
        //}
        
    }
}
