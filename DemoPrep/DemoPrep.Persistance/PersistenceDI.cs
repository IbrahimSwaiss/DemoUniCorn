using DemoPrep.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DemoPrep.Persistance {
    public static class PersistenceDI {
        public static void AddPersistenceScoped(this IServiceCollection service) {
            service.AddScoped<IUoW, UoW>();
            service.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            service.AddScoped<IOwnerRepository, OwnerRepository>();
        }
    }
}