using System.Collections.Generic;
using System.Threading.Tasks;
using DemoPrep.Domain.Interfaces;

namespace DemoPrep.Persistance {
    public interface IRepository<TId, TEntity> where TEntity : class, IEntity<TId> {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IList<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteByIdAsync(TId entityId);
        void Delete(TEntity entity);
    }
}
