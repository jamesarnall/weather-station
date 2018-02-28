using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherStation.Models;
using WeatherStation.Services;

namespace WeatherStation.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {

        private readonly IWeatherService _service;

        public WeatherController(IWeatherService weatherService) 
        {
            _service = weatherService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            WeatherViewModel weather = await _service.GetWeatherAsync();
            return Ok(weather);
        }
    }
}
