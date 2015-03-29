using System.Threading.Tasks;
using DI_UoW.Data.DbContext;
using DI_UoW.Data.Infrastructure;
using DI_UoW.Data.Repositories.User;
using DI_UoW.Data.Repositories.Role;
using DI_UoW.Model.Entities;

namespace DI_UoW.Data.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        public async virtual Task<int> CommitAsync()
        {
            return await m_dataContext.SaveChangesAsync();
        }

        readonly System.Data.Entity.DbContext m_dataContext;

        public UnitOfWork()
        {
            m_dataContext = new DI_UoW_DbContext();
        }


        /// <summary>
        /// Repository defenitions
        /// </summary>

        IUserRepository m_userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                return m_userRepository ?? (m_userRepository = new UserRepository());
            }
        }

        IRoleRepository m_roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {
                return m_roleRepository ?? (m_roleRepository = new RoleRepository());
            }
        }
    }
}
