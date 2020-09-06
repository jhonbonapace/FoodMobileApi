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
        public UserDTO User { get; set; }
        public DateTime SetOn { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class PasswordRecoveryDTOValidator : AbstractValidator<PasswordRecoveryDTO>
    {
        public PasswordRecoveryDTOValidator()
        {
            RuleFor(c => c.Email)
           .NotEmpty().WithMessage("O campo e-mail deve ser informado")
           .EmailAddress().WithMessage("E-mail inválido");
        }
    }
}
