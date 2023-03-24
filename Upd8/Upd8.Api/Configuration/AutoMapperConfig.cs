using Upd8.Manager.Mappings;

namespace Upd8.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AtualizaClienteMappingProfile));
        }
    }
}
