using Serilog;

namespace Upd8.Api.Configuration
{
    public static class SerilogConfig
    {
        public static void AddSerilog(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        }
    }
}
