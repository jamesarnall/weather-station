using System;
using WeatherStation.Models;

namespace WeatherStation.Services 
{
    public class WeatherService: IWeatherService 
    {

        /// <inheritdoc />
        public Weather GetWeather() 
        {
            throw new NotImplementedException("WeatherService.GetWeather NOT IMPLEMENTED");
        }

        /// <inheritdoc />
        public string GetDayOrNight(DateTime currentTime) 
        {
            throw new NotImplementedException("WeatherService.GetDayOrNight NOT IMPLEMENTED");
        }
    }
}
