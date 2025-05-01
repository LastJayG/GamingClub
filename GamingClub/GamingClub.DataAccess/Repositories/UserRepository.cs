using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;
using GamingClub.Data.Context;
using GamingClub.Data.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data.Repositories
{
    public class UserRepository(GamingClubContext gamingClubContext) : IUserRepository
    {
        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await gamingClubContext.Users
                .Include(u => u.Reservations)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var user = new UserEntity();
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            gamingClubContext.Users.Add(user);
            await gamingClubContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDTO newUserDTO)
        {
            var user = await gamingClubContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == newUserDTO.Id);
            user.Username = newUserDTO.Username;
            user.Email = newUserDTO.Email;
            gamingClubContext.Users.Update(user);
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
