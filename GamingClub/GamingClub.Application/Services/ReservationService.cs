using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class ReservationService(IReservationRepository reservationRepository,
        IReservationUnitService reservationUnitService) : IReservationService
    {
        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            return (await reservationRepository.GetReservationByIdAsync(id)).MapToReservationDTO();
        }

        public async Task CreateReservationAsync(ReservationCreateDTO reservation)
        {
            // тоже какой-то страшненький и нелоканичный КОСТЫЛЬ
            var reservationUnitsToRegister = from unit in reservation.ReservationUnits
                                             select unit.MapToReservationUnitEntity();
            foreach (var unit in reservationUnitsToRegister)
            {
                await reservationUnitService.CreateReservationUnitAsync(unit.MapToReservationUnitCreateDTO());
            }
            var reservationEntity = reservation.MapToReservationEntity();
            await reservationRepository.CreateReservationAsync(reservationEntity);
        }

        public async Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id)
        {
            var reservationEntity = reservation.MapToReservationEntity();
            await reservationRepository.UpdateReservationAsync(reservationEntity);
        }

        public async Task DeleteReservationByIdAsync(int id)
        {
            await reservationRepository.DeleteReservationByIdAsync(id);
        }
    }
}
