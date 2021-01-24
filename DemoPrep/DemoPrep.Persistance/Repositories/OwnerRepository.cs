using DemoPrep.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrep.Persistance.Repositories {
    public class OwnerRepository : Repository<int, Owner>, IOwnerRepository {
        private readonly ApplicationDbContext _dbContext;

        public OwnerRepository(ApplicationDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Owner> GetOwnerWithUnicornsAsync(int id) {
            var query = from owner in _dbContext.Set<Owner>().Include(o => o.Unicorns)
                        where owner.Id == id
                        select owner;

            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<Owner>> GetOwnersWithUnicornsAsync() {

            var query = from owner in _dbContext.Set<Owner>().Include(o => o.Unicorns)
                        select owner;

            return await query.ToListAsync();
        }
    }
}