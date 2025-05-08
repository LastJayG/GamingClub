using GamingClub.Core.Entities;
using GamingClub.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Services
{
    public class UserService : IUserService
    {
        private readonly GamingClubContext _context;
        public UserService(GamingClubContext context)
        {
            _context = context;
        }
        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task CreateUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
