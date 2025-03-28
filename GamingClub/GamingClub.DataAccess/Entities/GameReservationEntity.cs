using GamingClub.Core.Models.GameTariff;

namespace GamingClub.DataAccess.Entities
{
    public class GameReservationEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public GameTariffPrice Price { get; set; }
        public ReservedTimeEntity ReservedTime { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
