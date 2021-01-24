using System.Collections.Generic;
using System.Threading.Tasks;
using DemoPrep.Domain.Entities;

namespace DemoPrep.Persistance
{
    public interface IOwnerRepository : IRepository<int, Owner>
    {
        Task<Owner> GetOwnerWithUnicornsAsync(int id);
        Task<List<Owner>> GetOwnersWithUnicornsAsync();
    }
}