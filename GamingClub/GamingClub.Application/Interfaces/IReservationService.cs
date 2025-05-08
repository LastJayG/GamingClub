using GamingClub.Application.DTOs.Reservation;

namespace GamingClub.Application.Interfaces
{
    public interface IReservationService
    {
        public Task CreateReservationAsync(ReservationCreateDTO reservation);
        public Task<ReservationDTO> GetReservationByIdAsync(int id);
        public Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id);
        public Task DeleteReservationByIdAsync(int id);
    }
}
