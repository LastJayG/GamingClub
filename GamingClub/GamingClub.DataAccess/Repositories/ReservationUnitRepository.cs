using GamingClub.Data.Context;
using GamingClub.Domain.Entities;
using GamingClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data.Repositories
{
    public class ReservationUnitRepository(GamingClubContext gamingClubContext) : IReservationUnitRepository
    {
        public async Task<ReservationUnitEntity> GetReservationUnitByIdAsync(int id)
        {
            return await gamingClubContext.ReservationUnits
                .Include(ru => ru.ReservationId)
                .AsNoTracking()
                .FirstOrDefaultAsync(ru => ru.Id == id);
        }
        public async Task CreateReservationUnitAsync(ReservationUnitEntity reservationUnit)
        {
            gamingClubContext.ReservationUnits.Add(reservationUnit);
            await gamingClubContext.SaveChangesAsync();
        }
        //public Task UpdateReservationUnitAsync(ReservationUnitEntity reservationUnit)
        //{

        //}
        //public Task DeleteReservationUnitByIdAsync(int id)
        //{

        //}
    }
}
