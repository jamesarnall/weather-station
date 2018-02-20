using System;
using System.Collections.Generic;
using WeatherStation.Models;

namespace WeatherStation.Services 
{
    public class MockWeatherService : IWeatherService
    {
        public Weather GetWeather() {
            return new Weather {
                ConditionsShort = "cloudy".ToLower(),
                ConditionsDesc  = "Cloudyyyyy",
                DayOrNight      = GetDayOrNight().ToLower(),
                CurrentDate     = "February 19, 2018",
                CurrentTime     = "4:17 PM",
                Temperature     = "88"
            };
        }

        public string GetDayOrNight() 
        {
            return "Day";
        }
    }
}