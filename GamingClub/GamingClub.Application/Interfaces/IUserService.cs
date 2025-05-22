using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserByIdAsync(int id);
        public Task<UserWithReservationsDTO> GetUserWithReservationsByIdAsync(int id);
        public Task CreateUserAsync(UserDTO user);
        public Task UpdateUserAsync(UserUpdateDTO user, int id);
        public Task DeleteUserByIdAsync(int id);
        public Task<UserDTO?> GetUserFromFileAsync(int id);
    }
}
