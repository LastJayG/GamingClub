using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;

namespace GamingClub.Data.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> GetUserByIdAsync(int id);
        public Task CreateUserAsync(UserDTO userDTO);
        public Task UpdateUserAsync(UserDTO userDTO);
        public Task DeleteUserByIdAsync(int id);
    }
}
