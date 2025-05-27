using GamingClub.Application.DTOs.Reservation;

namespace GamingClub.Application.Interfaces
{
    public interface IReservationService
    {
        public Task<ReservationDTO> GetReservationByIdAsync(int id);
        public Task CreateReservationAsync(ReservationDTO reservation);
        public Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id, int userId);
        public Task DeleteReservationByIdAsync(int id);

        public Task CheckReservationTime(ReservationDTO reservationDTO);
        public Task<List<TimeSpan>> ReturnAvailableReservationStartTimePointsAsync(TimeSpan timeSpan);
    }
}
