using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task CreateUserAsync(UserCreateDTO user)
        {
            var userEntity = user.MapToUserEntity();
            await userRepository.CreateUserAsync(userEntity);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = (await userRepository.GetUserByIdAsync(id)).MapToUserDTO();
            return user;
        }

        public async Task UpdateUserAsync(UserUpdateDTO user, int id)
        {
            var userEntity = user.MapToUserEntity();
            await userRepository.UpdateUserAsync(userEntity, id);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await userRepository.DeleteUserByIdAsync(id);
        }
    }
}
