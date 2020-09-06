using Domain.Entities;
using FluentValidation;
using System;

namespace Application.DTO
{
    public class PasswordRecoveryDTO : Base
    {
        public string HashKey { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public UserDTO User { get; set; }
        public DateTime SetOn { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class PasswordRecoveryDTOValidator : AbstractValidator<PasswordRecoveryDTO>
    {
        public PasswordRecoveryDTOValidator()
        {
            RuleFor(c => c.HashKey).NotNull();
            RuleFor(c => c.Id).NotNull().NotEqual(0);

            RuleFor(c => c.Email)
           .NotEmpty().WithMessage("O campo e-mail deve ser informado")
           .EmailAddress().WithMessage("E-mail inválido");

           RuleFor(c => c.Password)
          .NotEmpty().WithMessage("O campo senha deve ser informado")
          .Length(4, 50).WithMessage("O campo senha deve ter entre 3 e 50 caracteres");

            RuleFor(c => c.PasswordConfirmed)
           .NotEmpty().WithMessage("O campo confirmar senha deve ser informado")
           .Length(4, 50).WithMessage("O campo confirmar deve ter entre 3 e 50 caracteres");
        }
    }
}
