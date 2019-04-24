using System.Threading.Tasks;
using Moq;
using WeatherStation.Models;
using WeatherStation.Services;
using Xunit;

namespace WeatherStation.Tests.Services
{
    public class WeatherStationServiceTests
    {
        private readonly Mock<IWeatherService> _serviceMock;
        // private readonly IWeatherService _service;

        public WeatherStationServiceTests()
        {
            _serviceMock = new Mock<IWeatherService>();
            // _service = new MockWeatherService();
        }

        [Fact]
        public async Task GetWeatherAsync_returns_Weather_obj()
        {
            _serviceMock
                .Setup(repo => repo.GetWeatherAsync())
                .Returns(Task.FromResult(MockHelpers.GetMockWeatherView()));
            WeatherViewModel weather = await _serviceMock.Object.GetWeatherAsync();
            Assert.Equal("night", weather.DayOrNight);
        }

        /*[Fact]
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

        [Fact]
        public void GetDayOrNight_returns_night_at_night()
        {
            var dt = DateTime.Parse("1/1/2018 10:01PM");
            string result = _service.GetDayOrNight(dt);
            Assert.Equal("day", result.ToLower());
        }

        [Fact]
        public async Task GetSunriseSunsetResultAsync_returns_data_obj()
        {
            // var dt = DateTime.Parse("1/1/2018 10:01PM");
            SunriseSunsetResult result = await _service.GetSunriseSunsetResultAsync();
            Assert.Equal(DateTime.Parse("1/1/01 8:00AM"), result.results.sunrise);
        }

        */
    }
}