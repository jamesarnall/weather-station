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
            WeatherViewModel weather = await _service.GetWeatherAsync();
            return Ok(weather);
        }
    }
}
