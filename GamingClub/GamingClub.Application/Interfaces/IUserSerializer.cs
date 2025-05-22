
using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Interfaces
{
    public interface IUserSerializer
    {
        public Task<UserDTO?> DeserializeFromFileAsync(int userId);
        public Task SerializeToFileAsync(UserDTO user);
    }
}
