using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using DarkSkyApi;
using DarkSkyApi.Models;
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

            return Ok(_service.GetWeather());
            // var client = new DarkSkyService("c35a1260e1e4fcd3638d98ff589fdb20");
            
            // Forecast result = await client.GetTimeMachineWeatherAsync(41.9196671, -87.6408105, DateTimeOffset.Now);
            
            // return Ok(new Weather(result));
        }
    }
}
