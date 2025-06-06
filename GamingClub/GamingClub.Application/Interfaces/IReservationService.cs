using GamingClub.Application.DTOs.Reservation;

namespace GamingClub.Application.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationRequestDTO> GetReservationByIdAsync(int id);
        public Task CreateReservationAsync(ReservationRequestDTO reservation);
        public Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id, int userId);
        public Task DeleteReservationByIdAsync(int id);

        public Task<List<string>> GetAvailableTimeSlotsAsync(TimeSpan duration);

    }
}
