using System;
using System.Collections.Generic;
using WeatherStation.Models;

namespace WeatherStation.Services 
{
    public class MockWeatherService : IWeatherService
    {

        public Weather GetWeather() {

            DateTime currentTime = DateTime.Parse("1/1/2018 12:01PM");
            
            return new Weather {
                ConditionsShort = "cloudy".ToLower(),
                ConditionsDesc  = "Cloudyyyyy",
                DayOrNight      = GetDayOrNight(currentTime).ToLower(),
                CurrentDate     = "February 19, 2018",
                CurrentTime     = "4:17 PM",
                Temperature     = "88"
            };
        }
        
        
        public string GetDayOrNight(DateTime currentTime) 
        {
            return "Day";
        }
    }
}