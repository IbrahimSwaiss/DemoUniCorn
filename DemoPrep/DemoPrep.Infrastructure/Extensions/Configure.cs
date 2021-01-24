using DemoPrep.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DemoPrep.Infrastructure.Extensions {
    public static class Configure {
        public static void ConfigureSwagger(this IApplicationBuilder app) {
            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
                c.RoutePrefix = "api";
            });
        }
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app) {
            app.UseMiddleware<ApplicationExceptionMiddleware>();
        }
    }
}