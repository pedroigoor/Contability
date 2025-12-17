using Gs_Contability.Repositories.Users;

namespace Gs_Contability.Config
{
    public static class RepositoriesConfig
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
