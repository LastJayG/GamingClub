using GamingClub.Application.DTOs.ReservationUnit;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class ReservationUnitService(IReservationUnitRepository reservationUnitRepository) : IReservationUnitService
    {
        public async Task CreateReservationUnitAsync(ReservationUnitCreateDTO reservationUnit)
        {
            var reservationUnitEntity = reservationUnit.MapToReservationUnitEntity();
            reservationUnitRepository.CreateReservationUnitAsync(reservationUnitEntity);
        }
        //public Task<ReservationUnitDTO> GetReservationUnitByIdAsync(int id);
        //public Task UpdateReservationUnitAsync(ReservationUnitUpdateDTO reservation, int id);
        //public Task DeleteReservationUnitByIdAsync(int id);
    }
}
