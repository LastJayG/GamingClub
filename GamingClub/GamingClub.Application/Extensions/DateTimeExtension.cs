namespace GamingClub.Application.Extensions
{
    public static class DateTimeExtension
    {
        public static string GetDateCustomFormat(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string GetTimeCustomFormat(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm");
        }
    }
}
