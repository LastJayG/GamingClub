using GamingClub.Application.DTOs.Reservation;

namespace GamingClub.Application.DTOs.User
{
    public class UserWithReservationsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<ReservationDTO> Reservations { get; set; }
    }
}
