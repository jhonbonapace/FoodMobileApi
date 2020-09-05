using Domain.Entities;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static Domain.Enumerators.Enumerator;

namespace Application.DTO
{
    public class UserDTO : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Telephone { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public byte[] Thumbnail { get; set; }
        public UserType UserType { get; set; }
        public int FailedAttempts { get; set; }
        [JsonIgnore]
        public string PasswordConfirmed { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Deleted { get; set; }
        public string Ip { get; set; }
        public UserSettings UserSettings { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<UserCommentaries> UserCommentaries { get; set; }
        public virtual ICollection<UserFavoriteCustomers> UserFavoriteCustomers { get; set; }


    }

    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("O campo nome deve ser informado")
           .Length(3, 200).WithMessage("O campo nome deve ter entre 3 e 150 caracteres");

            RuleFor(c => c.Email)
           .NotEmpty().WithMessage("O campo e-mail deve ser informado")
           .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(c => c.Telephone)
            .NotEmpty().WithMessage("O campo telefone deve ser informado");

            RuleFor(c => c.Password)
            .NotEmpty().WithMessage("O campo senha deve ser informado")
            .Length(4, 50).WithMessage("O campo senha deve ter entre 3 e 50 caracteres");

            RuleFor(c => c.PasswordConfirmed)
           .NotEmpty().WithMessage("O campo confirmar senha deve ser informado")
           .Length(4, 50).WithMessage("O campo confirmar deve ter entre 3 e 50 caracteres");
        }
    }
}
