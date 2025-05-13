namespace GamingClub.Application.DTOs.ReservationUnit
{
    public class ReservationUnitDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ReservationId { get; set; }
        public int GamingStationId { get; set; }
    }
}
