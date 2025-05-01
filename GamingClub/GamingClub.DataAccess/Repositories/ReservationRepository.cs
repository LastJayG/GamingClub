using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;
using GamingClub.Data.Context;
using GamingClub.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public async Task CreateReservationAsync(ReservationDTO reservationDTO)
        {
            var user = await gamingClubContext.Users
                .Include(u => u.Reservations) // Подгружаем связанные резервации
                .FirstOrDefaultAsync(u => u.Id == reservationDTO.UserId);
            var reservation = new ReservationEntity();
            reservation.StartDate = reservationDTO.StartDate;
            reservation.EndDate = reservationDTO.EndDate;
            reservation.UserId = reservationDTO.UserId;

            user.Reservations ??= new List<ReservationEntity>();
            user.Reservations.Add(reservation);

            gamingClubContext.Reservations.Add(reservation);

            await gamingClubContext.SaveChangesAsync();
        }
        public async Task UpdateReservationAsync(ReservationDTO reservationDTO)
        {
            var reservation = await gamingClubContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == reservationDTO.Id);
            reservation.StartDate = reservationDTO.StartDate;
            reservation.EndDate = reservationDTO.EndDate;
            reservation.UserId = reservationDTO.UserId;

            gamingClubContext.Reservations.Update(reservation);
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
