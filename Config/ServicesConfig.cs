
using Gs_Contability.Dto.Users;
using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Pagination;
using Gs_Contability.Services.Users;

namespace Gs_Contability.Config
{
    public static class ServicesConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
           

            services.AddScoped<IUserService, UserService>();
        


        }
    }
}
