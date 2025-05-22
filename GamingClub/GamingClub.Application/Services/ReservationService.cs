using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class ReservationService(IReservationRepository reservationRepository) : IReservationService
    {
        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            return (await reservationRepository.GetReservationByIdAsync(id))
                    .MapToReservationDTO();
        }

        public async Task CreateReservationAsync(ReservationDTO reservation)
        {
            var reservationEntity = reservation.MapToReservationEntity();
            await reservationRepository.CreateReservationAsync(reservationEntity);
        }

        public async Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id)
        {
            var reservationEntity = reservation.MapToReservationEntity(id);
            await reservationRepository.UpdateReservationAsync(reservationEntity);
        }

        public async Task DeleteReservationByIdAsync(int id)
        {
            await reservationRepository.DeleteReservationByIdAsync(id);
        }
    }
}
