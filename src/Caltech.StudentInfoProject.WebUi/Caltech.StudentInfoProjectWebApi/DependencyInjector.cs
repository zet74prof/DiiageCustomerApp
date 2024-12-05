using Caltec.Dependency.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Caltec.Dependency
{

    public static class DependencyInjectorExtensions
    {
        public static void AddCalTechDependency(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StudentInfoDbContext>(
            options =>
            {
                options.UseSqlServer(connectionString, o => o.EnableRetryOnFailure());

            }, ServiceLifetime.Transient);

            // Register your dependencies here

            // Add more dependencies as needed

            // Register Swagger
            services.AddSwaggerGen();

            // Add MVC services
            services.AddMvc();

            // Add MVC middleware
            services.AddMvcCore().AddApiExplorer();

            // Add MVC routing
            services.AddRouting();

            // Add MVC endpoints
            services.AddControllers();

            // Add Swagger UI middleware

        }

        public static IApplicationBuilder UseCaltechDependency(
            this IApplicationBuilder app
          )
        {

            app.UseSwagger();
            return app.UseSwaggerUI();
        }
    }
}
