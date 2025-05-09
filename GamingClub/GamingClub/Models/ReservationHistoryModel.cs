using GamingClub.Models.Prices;

namespace GamingClub.Models
{
    public class ReservationHistoryModel    
    {
        bool isExpired = false;
        public required Dictionary<bool, GameModel> ReservedGamesHistory { get; set; }
        public void AddGameToHistory(GameModel game)
        {
            DateTime currentTime = DateTime.Now;
            int compareResult = DateTime.Compare(game.EndTime, currentTime);
            if (compareResult < 0)
                isExpired = false;
            else
                isExpired = true;
            ReservedGamesHistory.Add(isExpired, game);
        }
    }
}
