using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DI_UoW.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
    }
}
