using System;
using WeatherStation.Services;
using Xunit;

namespace WeatherStation.Tests
{
    public class WeatherStationServiceTests
    {
        private readonly IWeatherService _service;

        public WeatherStationServiceTests()
        {
            _service = new WeatherService();
        }

        [Fact]
        public void GetDayOrNight_returns_day_at_day()
        {
            var dt = DateTime.Parse("1/1/2018 12:01PM");
            string result = _service.GetDayOrNight(dt);
            Assert.Equal("day", result);
        }

        [Fact]
        public void GetDayOrNight_returns_night_at_night()
        {
            var dt = DateTime.Parse("1/1/2018 10:01PM");
            string result = _service.GetDayOrNight(dt);
            Assert.Equal("night", result);
        }
    }
}