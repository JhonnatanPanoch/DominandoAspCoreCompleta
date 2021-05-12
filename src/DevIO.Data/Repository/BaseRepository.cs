using DevIO.Bussiness.Interfaces.Repository;
using DevIO.Bussiness.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CustomDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(CustomDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> List()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Insert(TEntity model)
        {
            _dbSet.Add(model);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity model)
        {
            _dbSet.Update(model);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
