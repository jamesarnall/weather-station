using System;
using System.IO;
using System.Threading.Tasks;
using WeatherStation.Models;
using WeatherStation.Services;
using Xunit;

namespace WeatherStation.Tests
{
    public class DarkSkyTests
    {
        private readonly IDarkSkyApiService _service;

        public DarkSkyTests()
        {
            _service = new DarkSkyApiService();
        }

        [Fact]
        public void DarkSkyService_returns_DarkSkyResult()
        {
            DarkSkyResult result = _service.GetDarkSkyResult(TestHelpers.GetDarkSkyJson());
            Assert.Equal("America/Chicago", result.Timezone);
        }

        [Fact]
        public void MapDarkSkyToWeather_returns_Weather()
        {
            DarkSkyResult result = _service.GetDarkSkyResult(TestHelpers.GetDarkSkyJson());

            WeatherViewModel weather = _service.MapDarkSkyToWeather(result);

            Assert.Equal("yyy", weather.FeelsLike);
        }
    }
}