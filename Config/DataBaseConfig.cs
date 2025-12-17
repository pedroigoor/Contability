using Gs_Contability.Data;

namespace Gs_Contability.Config
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
        }
    }

}
