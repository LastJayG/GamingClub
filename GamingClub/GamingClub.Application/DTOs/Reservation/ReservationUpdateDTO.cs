namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationUpdateDTO
    {
        public int GamingStationId { get; set; }

        public DateTime StartDate;
        public DateTime EndDate;
        public string StartDateShort => StartDate.ToString("yyyy-MM-dd HH:mm");
        public string EndDateShort => EndDate.ToString("yyyy-MM-dd HH:mm");
    }
}
