using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class UserService(IUserRepository userRepository, 
                             IUserSerializer userSerializer) : IUserService
    {

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = (await userRepository.GetUserByIdAsync(id)).MapToUserDTO();
            await userSerializer.SerializeToFileAsync(user);

            return user;
        }
        public async Task<UserWithReservationsDTO> GetUserWithReservationsByIdAsync(int id)
        {
            var user = (await userRepository.GetUserWithReservationsByIdAsync(id)).MapToUserWithReservationsDTO();

            return user;
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            var userEntity = user.MapToUserEntity();
            await userRepository.CreateUserAsync(userEntity);
        }

        public async Task<UserDTO?> GetUserFromFileAsync(int id)
        {
            return await userSerializer.DeserializeFromFileAsync(id);
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
