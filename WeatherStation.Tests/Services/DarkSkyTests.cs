using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using WeatherStation;
using WeatherStation.Models;
using WeatherStation.Services;
using Xunit;

namespace WeatherStation.Tests
{
    public class DarkSkyTests
    {
        private readonly IDarkSkyApiService _service;
        // private readonly Assembly           _assembly;

        public DarkSkyTests()
        {
            // _assembly = Assembly.GetEntryAssembly();
            _service  = new DarkSkyApiService();
        }

        [Fact]
        public void DarkSkyService_returns_DarkSkyResult()
        {
            DarkSkyResult result = _service.GetDarkSkyResult(MockHelpers.GetDarkSkyJson());
            Assert.Equal("America/Chicago", result.Timezone);
        }

        [Fact]
        public void MapDarkSkyToWeather_returns_Weather()
        {
            DarkSkyResult result = _service.GetDarkSkyResult(MockHelpers.GetDarkSkyJson());

            WeatherViewModel weather = _service.MapDarkSkyToWeather(result);

            Assert.Equal("yyy", weather.FeelsLike);
        }
    }
}