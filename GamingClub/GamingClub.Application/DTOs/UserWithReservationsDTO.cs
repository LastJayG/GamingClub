namespace GamingClub.Application.DTOs
{
    public class UserWithReservationsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<ReservationDTO> Reservations { get; set; }
    }
}
