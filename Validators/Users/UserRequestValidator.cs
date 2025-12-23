using FluentValidation;
using Gs_Contability.Data;
using Gs_Contability.Dto.Users;
using Microsoft.EntityFrameworkCore;

namespace Gs_Contability.Validators.Users
{
    public class UserRequestValidator : AbstractValidator<UserRequestDTO>
    {

        private readonly Context _context;

        public UserRequestValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("Formato de e-mail inválido.")
            .MustAsync(async (email, cancellation) =>
            {
                var exists = await _context.Users
                    .AnyAsync(u => u.Email == email, cancellation);

                return !exists;
            })
            .WithMessage("Este e-mail já está cadastrado.");

                    RuleFor(x => x.PasswordHash)
                        .NotEmpty().WithMessage("A senha é obrigatória.")
                        .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

                    RuleFor(x => x.Username)
                        .NotEmpty().WithMessage("O nome completo é obrigatório.")
                        .MaximumLength(100).WithMessage("O nome completo não pode ultrapassar 100 caracteres.");
        }
    }
}
