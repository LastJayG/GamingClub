using FluentValidation;
using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Validation.User
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator() 
        {
            RuleFor(userDTO => userDTO.Email).EmailAddress();
            RuleFor(userDTO => userDTO.Username).MaximumLength(30);
        }
    }
}
