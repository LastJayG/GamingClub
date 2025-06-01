using FluentValidation;
using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Validation.User
{
    public class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(userDTO => userDTO.Email).EmailAddress();
            RuleFor(userDTO => userDTO.Username).MaximumLength(30);
        }
    }
}
