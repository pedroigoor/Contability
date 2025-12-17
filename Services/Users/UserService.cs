using AutoMapper;

using Gs_Contability.Dto.Users;
using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Pagination;
using Gs_Contability.Repositories.Users;

namespace Gs_Contability.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> CreateAsync(UserRequestDTO modelRequest)
        {
            var model = _mapper.Map<User>(modelRequest);
            var createdModel = await _userRepository.CreateAsync(model);
            return _mapper.Map<UserResponseDTO>(createdModel);

        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public PagedResult<UserResponseDTO> FindAll(int page, int size)
        {
            var pagedUsers = _userRepository.FindAllPaged(page, size);

            return _mapper.Map<PagedResult<UserResponseDTO>>(pagedUsers);

        }

        public UserResponseDTO FindById(int id)
        {
            ExistsById(id);

            var model = _userRepository.FindById(id);

            return _mapper.Map<UserResponseDTO>(model);
        }

        public Task<UserResponseDTO> UpdateById(int id, UserRequestDTO modelRequest)
        {
            throw new NotImplementedException();
        }

        private void ExistsById(int id)
        {
            if (!_userRepository.ExistsById(id))
            {
                //throw new ModelNotFoundException("Aeronave não encontrada");
            }
        }


    }
}
