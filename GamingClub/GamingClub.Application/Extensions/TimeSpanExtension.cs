namespace GamingClub.Application.Extensions
{
    public static class TimeSpanExtension
    {
        /// <summary>
        /// Проверяет, помещается ли timeSpan (промежуток времени) в границы firstTime и secondTime
        /// !!Хотя еще не использован (нужен будет для проверки свободных слотов)
        /// </summary>
        public static bool IsInTimeSlot(this TimeSpan timeSpan, TimeSpan firstTime, TimeSpan secondTime)
        {
            TimeSpan interval = secondTime - firstTime;
            return (timeSpan <= interval) ? true : false;
        }
    }
}
