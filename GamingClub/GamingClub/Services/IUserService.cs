using GamingClub.Models;

namespace GamingClub.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserModel user);
    }
}
