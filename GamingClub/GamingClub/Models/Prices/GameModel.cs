namespace GamingClub.Models.Prices
{
    public class GameModel
    {
        public string? Time { get; set; }
        public double CasualPriceStandard { get; set; }
        public double WeekendPriceStandard { get; set; }
        public double CasualPriceVip { get; set; }
        public double WeekendPriceVip { get; set; }
        public int Id { get; set; }
    }
}
