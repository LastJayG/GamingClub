using GamingClub.Core.Models.User;

namespace GamingClub.Core.Models.GameTariff
{
    public enum GameTariffPrice  //per hour
    {
        CasualPriceStandard = 8,
        CasualPriceVip = 10,
        WeekendPriceStandard = 11,
        WeekendPriceVip = 13,
    }
    public class GameReservationModel
    {
        public string? Time { get; set; }
        public GameTariffPrice Price { get; set; }
        public int OrderId { get; set; }
        public ReservedTimeModel ReservedTime { get; set; }
        public UserModel User { get; set; }
    }
}
