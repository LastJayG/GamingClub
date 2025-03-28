namespace GamingClub.Core.Models
{
    public class ReservedTimeModel
    {
        public DateOnly StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly EndTime { get; set; }

    }
}
