namespace GamingClub.Models.Prices
{
    public class GameModel  // модель игры для заказа (бронирование места для игры)
    {
        public string? Time { get; set; }
        public double CasualPriceStandard { get; set; }
        public double WeekendPriceStandard { get; set; }
        public double CasualPriceVip { get; set; }
        public double WeekendPriceVip { get; set; }
        public int Id { get; set; }

        // game goes from xx:xx (StartTime) till xx:xx (EndTime)
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set;}
    }
}
