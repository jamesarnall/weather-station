
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public class MockDarkSkyApiService : IDarkSkyApiService 
    {
        /// <inheritdoc />
        public async Task<WeatherViewModel> GetWeatherAsync()
        {
            return new WeatherViewModel {
                ConditionsLabel = "rainy",
                ConditionsDesc  = "Rainy",
                DayOrNight      = "night",
                CurrentDate     = "1/12/2018",
                CurrentTime     = "10:33 AM",
                Temperature     = "99"
            };
        }

        /// <inheritdoc />
        public DarkSkyResult GetDarkSkyResult(string jsonData)
        {
            throw new NotImplementedException("DarkSkyApiService.GetDarkSkyResultAsync NOT IMPLEMENTED");
        }

        /// <inheritdoc />
        public WeatherViewModel MapDarkSkyToWeather(DarkSkyResult darkSky)
        {
            throw new NotImplementedException("DarkSkyApiService.MapDarkSkyToWeather NOT IMPLEMENTED");
        }


    }
}