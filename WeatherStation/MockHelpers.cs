using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using WeatherStation.Models;

namespace WeatherStation
{
    /*
        Possible icon values for Dark Sky
        clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, or partly-cloudy-night
    */
    public static class MockHelpers 
    {
        static readonly string _baseDir = Directory.GetCurrentDirectory();
        static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

        public static string GetDarkSkyJson() 
        {
            string json = "";
            var resourceStream = _assembly.GetManifestResourceStream("WeatherStation.Data.Mocks.darksky.json");
            using (StreamReader sr = new StreamReader(resourceStream, Encoding.UTF8))
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