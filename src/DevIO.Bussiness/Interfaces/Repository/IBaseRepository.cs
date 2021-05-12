using DevIO.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Get(Guid id);
        
        Task<IEnumerable<TEntity>> List();
        
        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
        
        Task Insert(TEntity model);
        
        Task Update(TEntity model);
        
        Task Delete(Guid id);

        Task<int> SaveChanges();
    }
}
