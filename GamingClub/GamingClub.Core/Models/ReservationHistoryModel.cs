using GamingClub.Core.Models.GameTariff;

namespace GamingClub.Models
{
    public class ReservationHistoryModel    
    {
        bool isExpired = false;
        public required Dictionary<bool, GameReservationModel> ReservedGamesHistory { get; set; }
        public void AddGameToHistory(GameReservationModel game)
        {
            //DateTime currentTime = DateTime.Now;
            //int compareResult = DateTime.Compare(game.EndTime, currentTime);
            //if (compareResult < 0)
            //    isExpired = false;
            //else
            //    isExpired = true;
            //ReservedGamesHistory.Add(isExpired, game);
        }
    }
}
