using GamingClub.Domain.Interfaces;
using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GamingClub.Data.Context;

namespace GamingClub.Data.Repositories
{
    public class UserRepository(GamingClubContext gamingClubContext) : IUserRepository
    {
        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await gamingClubContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity> GetUserWithReservationsByIdAsync(int id)
        {
            return await gamingClubContext.Users
                .Include(u => u.Reservations)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            gamingClubContext.Users.Add(user);
            await gamingClubContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserEntity user, int id)
        {
            var newUser = await gamingClubContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
            newUser.Username = user.Username;
            newUser.Email = user.Email;
            gamingClubContext.Users.Update(newUser);
            await gamingClubContext.SaveChangesAsync();
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            var user = await gamingClubContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
            gamingClubContext.Users.Remove(user);
            await gamingClubContext.SaveChangesAsync();
        }
    }
}
