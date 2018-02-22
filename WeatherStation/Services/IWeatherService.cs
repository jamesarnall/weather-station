using System;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the actual data we need to display the weather station panel
        /// </summary>
        Weather GetWeather();

        /// <summary>
        /// Tells us whether a given date/time was during the day or night
        /// </summary>
        string GetDayOrNight(DateTime currentTime);
    }
}