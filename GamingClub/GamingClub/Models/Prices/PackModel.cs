namespace GamingClub.Models.Prices
{
    public class PackModel  // пакет "утро", "ночь" и т.д.
    {
        public string? Name { get; set; }
        public double CasualPriceStandard { get; set; }
        public double WeekendPriceStandard { get; set; }
        public double CasualPriceVip { get; set; }
        public double WeekendPriceVip { get; set; }
    }
}
