using GamingClub.Application.DTOs.User;
using GamingClub.Application.Extensions;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GamingClub.Application.Services
{
    public class UserService(IUserRepository userRepository, IDistributedCache cache) : IUserService
    {
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            string cacheKey = $"User_{id}";
            var user = await cache.GetOrSetAsync(cacheKey,
                async () => await userRepository.GetUserByIdAsync(id)
            );
            return user.MapToUserDTO();
        }

        public async Task<UserWithReservationsDTO> GetUserWithReservationsByIdAsync(int id)
        {
            string cacheKey = $"UserWithReservations_{id}";
            var user = await cache.GetOrSetAsync(cacheKey,
                async () => await userRepository.GetUserWithReservationsByIdAsync(id)
            );
            return user.MapToUserWithReservationsDTO();
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            var userEntity = user.MapToUserEntity();
            await userRepository.CreateUserAsync(userEntity);

            string cacheKey = $"User_{userEntity.Id}";
            await cache.SetAsync(cacheKey, userEntity);
        }

        public async Task UpdateUserAsync(UserUpdateDTO user, int id)
        {
            var userEntity = user.MapToUserEntity();
            await userRepository.UpdateUserAsync(userEntity, id);

            string cacheKey = $"User_{id}";
            await cache.RemoveAsync(cacheKey);

            var updatedUser = await userRepository.GetUserByIdAsync(id);
            await cache.SetAsync(cacheKey, updatedUser);

            string reservationsCacheKey = $"UserWithReservations_{id}";
            await cache.RemoveAsync(reservationsCacheKey);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await userRepository.DeleteUserByIdAsync(id);

            await cache.RemoveAsync($"User_{id}");
            await cache.RemoveAsync($"UserWithReservations_{id}");
        }
    }
}