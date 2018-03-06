using System;
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
                ConditionsLabel = "clear",
                ConditionsDesc  = "Rainy",
                DayOrNight      = "night",
                CurrentDate     = "1/12/2018",
                CurrentTime     = "10:33 PM",
                Temperature     = "99"
            };
        }

        /// <inheritdoc />
        public DarkSkyResult GetDarkSkyResult(string jsonData)
        {
            throw new NotImplementedException("MockDarkSkyApiService.GetDarkSkyResultAsync NOT IMPLEMENTED");
        }

        /// <inheritdoc />
        public WeatherViewModel MapDarkSkyToWeather(DarkSkyResult darkSky)
        {
            throw new NotImplementedException("MockDarkSkyApiService.MapDarkSkyToWeather NOT IMPLEMENTED");
        }


    }
}