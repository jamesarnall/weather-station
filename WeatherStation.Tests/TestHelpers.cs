using Newtonsoft.Json;
using System;
using System.IO;
using WeatherStation.Models;

namespace WeatherStation.Tests
{
    public static class TestHelpers 
    {
        private static readonly string _baseDir = Directory.GetCurrentDirectory();

        public static string GetDarkSkyJson() 
        {
            string json = "";
            using (StreamReader sr = new StreamReader("Mocks/darksky.json"))
            {
            // Read the stream to a string, and write the string to the console.
                json = sr.ReadToEnd();
            }
            return json;
        }

        public static WeatherViewModel GetMockWeatherView()
        {
            return new WeatherViewModel 
            {
                ConditionsLabel = "cloudy".ToLower(),
                ConditionsDesc  = "Cloudyyyyy",
                DayOrNight      = "night",
                CurrentDate     = "February 19, 2018",
                CurrentTime     = "4:17 PM",
                FeelsLike       = "77",
                Temperature     = "88"
            };
        }
    }
}