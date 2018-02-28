using System;
using System.Threading.Tasks;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the actual data we need to display the weather station panel
        /// </summary>
        Task<WeatherViewModel> GetWeatherAsync();
    }
}