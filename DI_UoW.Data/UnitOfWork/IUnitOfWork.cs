using System;
using System.Threading.Tasks;
using DI_UoW.Data.Infrastructure;
using DI_UoW.Data.Repositories.User;
using DI_UoW.Data.Repositories.Role;
using DI_UoW.Model.Entities;

namespace DI_UoW.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        /// <summary>
        /// Repository intefaces
        /// </summary>
        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }
    }
}
