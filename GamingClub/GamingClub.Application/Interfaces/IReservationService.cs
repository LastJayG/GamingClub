using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.DTOs.User;

namespace GamingClub.Application.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationDTO> GetReservationByIdAsync(int id);
        public Task CreateReservationAsync(ReservationDTO reservation);
        public Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id);
        public Task DeleteReservationByIdAsync(int id);
    }
}
