using GamingClub.Core.Models.User;
using GamingClub.DataAccess.Entities;

namespace GamingClub.Services
{
    public interface IUserService
    {
        Task<UserEntity> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserEntity user);
    }
}
