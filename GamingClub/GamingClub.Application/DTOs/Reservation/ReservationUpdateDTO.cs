namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationUpdateDTO
    {
        public int GamingStationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateShort => StartDate.ToString("yyyy-MM-dd HH:mm");
        public string EndDateShort => EndDate.ToString("yyyy-MM-dd HH:mm");
    }
}
