namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GamingStationId { get; set; }

        public string ReservationDuration { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly Date {  get; set; }
    }
}
