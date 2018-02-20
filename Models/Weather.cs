using DarkSkyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherStation.Models
{
    public class Weather
    {
        public string ConditionsShort { get; set; }
        public string ConditionsDesc  { get; set; }
        public string DayOrNight      { get; set; }
        public string CurrentDate     { get; set; }
        public string CurrentTime     { get; set; }
        public string Temperature     { get; set; }
    }
}