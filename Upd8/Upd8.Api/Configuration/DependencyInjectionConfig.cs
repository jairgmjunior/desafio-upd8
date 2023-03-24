using Upd8.Data.Repository;
using Upd8.Manager.Implementation;
using Upd8.Manager.Interfaces;

namespace Upd8.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();

        }
    }
}
