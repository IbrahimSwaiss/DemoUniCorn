using DemoPrep.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoPrep.Infrastructure.Extensions {
    public static class ConfigureServices {
        public static void AddSwagger(this IServiceCollection services) {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }
        public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration) {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DemoConn")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        }
    }
}