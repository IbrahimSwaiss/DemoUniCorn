using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DemoPrep.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoPrep.Persistance.Repositories {
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, IEntity<TId> {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext dbContext) {
            Context = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(TId id) {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IList<TEntity>> GetAllAsync() {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task InsertAsync(TEntity entity) {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity) {
            Context.Set<TEntity>().Update(entity);
        }

        public async Task DeleteByIdAsync(TId entityId) {
            var entity = await GetByIdAsync(entityId);
            Delete(entity);
        }

        public void Delete(TEntity entity) {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
