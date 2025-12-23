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

        public async Task DeleteById(int id)
        {
            await ExistsById(id);
            await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<PagedResult<UserResponseDTO>> FindAll(int page, int size)
        {
            var pagedUsers = await _userRepository.FindAllPagedAsync(page, size);

            return _mapper.Map<PagedResult<UserResponseDTO>>(pagedUsers);

        }

        public async Task<UserResponseDTO> FindById(int id)
        {
            await ExistsById(id);

            var model = await _userRepository.FindByIdAsync(id);

            return _mapper.Map<UserResponseDTO>(model);
        }

        public async Task<UserResponseDTO> UpdateById(int id, UserRequestDTO modelRequest)
        {
            await ExistsById(id);

            // check email uniqueness if changed
            var existing = await _userRepository.FindByIdAsync(id);
            if (existing == null)
                throw new ModelNotFoundException("Usuario não encontrado");

            if (!string.Equals(existing.Email, modelRequest.Email, StringComparison.OrdinalIgnoreCase))
            {
                var emailExists = await _userRepository.EmailExistsAsync(modelRequest.Email);
                if (emailExists)
                    throw new GernericException("Email já cadastrado");
            }

            var jobToUpdate = _mapper.Map<User>(modelRequest);
            jobToUpdate.Id = id;

            // only hash if password was provided (not empty)
            if (!string.IsNullOrWhiteSpace(modelRequest.PasswordHash))
            {
                jobToUpdate.PasswordHash = BCrypt.Net.BCrypt.HashPassword(modelRequest.PasswordHash);
            }
            else
            {
                jobToUpdate.PasswordHash = existing.PasswordHash; // preserve existing
            }

            var updatedJob = await _userRepository.UpdateAsync(jobToUpdate);
            return _mapper.Map<UserResponseDTO>(updatedJob);

        }

        private async Task ExistsById(int id)
        {
            if (!await _userRepository.ExistsByIdAsync(id))
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
