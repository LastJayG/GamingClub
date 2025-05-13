using GamingClub.Domain.Entities;

namespace GamingClub.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserEntity> GetUserByIdAsync(int id);
        public Task CreateUserAsync(UserEntity user);
        public Task UpdateUserAsync(UserEntity user, int id);
        public Task DeleteUserByIdAsync(int id);
    }
}
