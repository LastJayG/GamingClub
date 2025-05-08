using GamingClub.Domain.Entities;

namespace GamingClub.Domain.Interfaces
{
    public interface IReservationUnitRepository
    {
        public Task<ReservationUnitEntity> GetReservationUnitByIdAsync(int id);
        public Task CreateReservationUnitAsync(ReservationUnitEntity reservationUnit);
        //public Task UpdateReservationUnitAsync(ReservationUnitEntity reservationUnit);
        //public Task DeleteReservationUnitByIdAsync(int id);
    }
}
