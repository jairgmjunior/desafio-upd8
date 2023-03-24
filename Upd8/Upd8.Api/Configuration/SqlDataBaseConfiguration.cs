using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Upd8.Data.Context;

namespace Upd8.Api.Configuration
{
    public static class SqlDataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Upd8Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var servicesScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = servicesScope.ServiceProvider.GetService<Upd8Context>();
            context?.Database.Migrate();
            context?.Database.EnsureCreated();
        }
    }
}
