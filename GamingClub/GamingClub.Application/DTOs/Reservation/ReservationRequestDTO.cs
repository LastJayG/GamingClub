namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GamingStationId { get; set; }

        public TimeSpan ReservationDuration { get; set; }
        public string StartTime { get; set; } // hh:mm
        public string Date {  get; set; } // yyyy-mm-dd
    }
}
