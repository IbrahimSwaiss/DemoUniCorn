using System.Threading.Tasks;

namespace DemoPrep.Persistance {
    public class UoW : IUoW {
        private readonly ApplicationDbContext _context;

        public UoW(ApplicationDbContext context) {
            _context = context;
        }
        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }
    }
}