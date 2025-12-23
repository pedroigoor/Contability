
using Gs_Contability.Dto.Users;
using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Pagination;
using Gs_Contability.Services.Users;

namespace Gs_Contability.Config
{
    public static class MappersConfig
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<User, UserRequestDTO>();
                cfg.CreateMap<UserRequestDTO, User>();

                cfg.CreateMap<User, UserResponseDTO>();
                cfg.CreateMap<UserResponseDTO, User>();
                cfg.CreateMap<User, UserRequestUpdateDTO>();
                cfg.CreateMap<UserRequestUpdateDTO, User>();

                cfg.CreateMap<PagedResult<User>, PagedResult<UserResponseDTO>>()
               .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            });

        


        }
    }
}
