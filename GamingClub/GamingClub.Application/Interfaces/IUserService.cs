using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Interfaces
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserCreateDTO user);
        public Task<UserDTO> GetUserByIdAsync(int id);
        public Task UpdateUserAsync(UserUpdateDTO user, int id);
        public Task DeleteUserByIdAsync(int id);
    }
}
