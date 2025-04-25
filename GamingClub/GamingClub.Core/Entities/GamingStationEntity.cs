namespace GamingClub.Core.Entities
{
    public class GamingStationEntity
    {
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public GamingStationType Type {  get; set; } 
        public List<ReservationEntity> Reservations { get; set; }
    }
}
