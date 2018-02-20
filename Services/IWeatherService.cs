using System;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public interface IWeatherService
    {
        /// <summary>
        ///   
        /// </summary>
        Weather GetWeather();

        /// <summary>
        ///   
        /// </summary>
        string GetDayOrNight();
    }
}