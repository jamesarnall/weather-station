using System;
using WeatherStation.Models;

namespace WeatherStation.Services 
{
    public class WeatherService: IWeatherService 
    {
        public Weather GetWeather() {
            throw new NotImplementedException("WeatherService.GetWeather NOT IMPLEMENTED");
        }

        public string GetDayOrNight() 
        {
            throw new NotImplementedException("WeatherService.GetDayOrNight NOT IMPLEMENTED");
        }
    }
}
