using FluentValidation;
using Gs_Contability.Dto.Users;
using Gs_Contability.Validators.Users;

namespace Gs_Contability.Config
{
    public static class ValidatorsConfig
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserRequestDTO>, UserRequestValidator>();
        }
    }
}
