namespace GamingClub.Application.DTOs.ReservationUnit
{
    public class ReservationUnitUpdateDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int GamingStationId { get; set; }
    }
}
