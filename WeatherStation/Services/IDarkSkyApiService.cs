using System;
using System.Threading.Tasks;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public interface IDarkSkyApiService : IWeatherService
    {
        /// <summary>
        /// Queries the Dark Sky API and returns a DTO
        /// </summary>
        /// <returns>DTO of type <see cref="DarkSkyResult"/></returns>
        DarkSkyResult GetDarkSkyResult(string jsonData);

        /// <summary>
        /// Maps the data retrieved from Dark Sky to a model better suited to our view
        /// </summary>
        /// <returns>DTO of type <see cref="WeatherViewModel"/></returns>
        WeatherViewModel MapDarkSkyToWeather(DarkSkyResult darkSky);
    }
}
