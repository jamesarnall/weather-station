using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherStation.Controllers;
using WeatherStation.Models;
using WeatherStation.Services;
using Xunit;

namespace WeatherStation.Tests.Controllers
{
    public class WeatherControllerTests
    {
        private Mock<IWeatherService> _serviceMock;
        private WeatherController     _controller;

        public WeatherControllerTests() 
        {
            _serviceMock = new Mock<IWeatherService>();
            _controller  = new WeatherController(_serviceMock.Object);
        }

        [Fact]
        public async Task WeatherController_returns_Weather()
        {
            _serviceMock
                .Setup(repo => repo.GetWeatherAsync())
                .Returns(Task.FromResult(MockHelpers.GetMockWeatherView())); 

            var result = await _controller.Get();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<WeatherViewModel>(viewResult.Value);

            WeatherViewModel srcView = MockHelpers.GetMockWeatherView();

            Assert.Equal(srcView.ConditionsLabel, model.ConditionsLabel);
            Assert.Equal(srcView.ConditionsDesc,  model.ConditionsDesc);
            Assert.Equal(srcView.DayOrNight,      model.DayOrNight);
            Assert.Equal(srcView.CurrentDate,     model.CurrentDate);
            Assert.Equal(srcView.CurrentTime,     model.CurrentTime);
            Assert.Equal(srcView.FeelsLike,       model.FeelsLike);
            Assert.Equal(srcView.Temperature,     model.Temperature);
        }

        // [Fact]
        // public async Task WeatherController_returns_Weather()
        // {
        // }

    }
}