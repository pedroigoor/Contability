using AutoMapper;
using FluentValidation;
using Gs_Contability.Dto.Users;
using Gs_Contability.Entities;
using Gs_Contability.Excepitons;
using Gs_Contability.Repositories.Common.Pagination;
using Gs_Contability.Repositories.Users;
using System.ComponentModel.DataAnnotations;

namespace Gs_Contability.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRequestDTO> _userDtoValidator;


        public UserService(IUserRepository userRepository, IMapper mapper, IValidator<UserRequestDTO> userDtoValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }
        public async Task<UserResponseDTO> CreateAsync(UserRequestDTO modelRequest)
        {
            await Validate(modelRequest);

            var emailExists = await _userRepository.EmailExistsAsync(modelRequest.Email);

            if (emailExists)
                throw new GernericException("Email já cadastrado");

            var model = _mapper.Map<User>(modelRequest);
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(modelRequest.PasswordHash);
            var createdModel = await _userRepository.CreateAsync(model);
            return _mapper.Map<UserResponseDTO>(createdModel);

        }

        public void DeleteById(int id)
        {
            ExistsById(id);
            _userRepository.DeleteById(id);
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

        public async Task<UserResponseDTO> UpdateById(int id, UserRequestDTO modelRequest)
        {
            ExistsById(id);

            var jobToUpdate = _mapper.Map<User>(modelRequest);
            jobToUpdate.Id = id;
            var updatedJob = await _userRepository.Update(jobToUpdate);
            return _mapper.Map<UserResponseDTO>(updatedJob);

        }

        private void ExistsById(int id)
        {
            if (!_userRepository.ExistsById(id))
            {
                throw new ModelNotFoundException("Usuario não encontrado");
            }
        }

        private async Task Validate(UserRequestDTO modelRequest)
        {
            await _userDtoValidator.ValidateAndThrowAsync(modelRequest);
        }

    }
}
