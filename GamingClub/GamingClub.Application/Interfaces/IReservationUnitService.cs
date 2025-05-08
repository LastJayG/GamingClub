using GamingClub.Application.DTOs.ReservationUnit;

namespace GamingClub.Application.Interfaces
{
    public interface IReservationUnitService
    {
        public Task CreateReservationUnitAsync(ReservationUnitCreateDTO reservation);
        //public Task<ReservationUnitDTO> GetReservationUnitByIdAsync(int id);
        //public Task UpdateReservationUnitAsync(ReservationUnitUpdateDTO reservation, int id);
        //public Task DeleteReservationUnitByIdAsync(int id);
    }
}
