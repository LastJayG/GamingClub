using GamingClub.Domain.Interfaces;
using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GamingClub.Data.Context;

namespace GamingClub.Data.Repositories
{
    public class ReservationRepository(GamingClubContext gamingClubContext) : IReservationRepository
    {
        public async Task<ReservationEntity> GetReservationByIdAsync(int id)
        {
            return await gamingClubContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateReservationAsync(ReservationEntity reservation)
        {
            gamingClubContext.Reservations.Add(reservation);
            await gamingClubContext.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(ReservationEntity reservation)
        {
            var newReservation = await gamingClubContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == reservation.Id);

            gamingClubContext.Reservations.Update(newReservation);
            await gamingClubContext.SaveChangesAsync();
        }

        public async Task DeleteReservationByIdAsync(int id)
        {
            var reservation = await gamingClubContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
            gamingClubContext.Reservations.Remove(reservation);
            await gamingClubContext.SaveChangesAsync();
        }

    }
}
