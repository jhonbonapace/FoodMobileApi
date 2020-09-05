using Domain.Entities;
using FluentValidation;

namespace Application.DTO
{
    public class UserFavoriteCustomerDTO : Base
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class UserFavoriteCustomerDTOValidator : AbstractValidator<UserFavoriteCustomerDTO>
    {
        public UserFavoriteCustomerDTOValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEqual(0);
            RuleFor(c => c.UserId).NotNull().NotEqual(0);
        }
    }
}
