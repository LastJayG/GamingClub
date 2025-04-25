namespace GamingClub.Core.Entities
{
    public class ReservationEntity    
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public List<GamingStationEntity> GameStations { get; set; }
    }
}
