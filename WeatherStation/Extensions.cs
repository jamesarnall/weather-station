using System;

namespace WeatherStation 
{
    public static class Extensions 
    {
        public static string DayOrNight(this DateTime nowTime, DateTime sunsetTime)
        {
            return (DateTime.Compare(nowTime, sunsetTime) < 0)
                    ? "day"
                    : "night"
            ;
        }

        public static DateTime InTimeZone(this DateTime nowTime, string timezoneName)
        {
            TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(timezoneName);
            return TimeZoneInfo.ConvertTimeFromUtc(nowTime, timezone);
        }
    }
}