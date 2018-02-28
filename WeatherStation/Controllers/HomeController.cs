using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherStation.Models;
using WeatherStation.Services;

namespace WeatherStation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _service;

        public HomeController(IWeatherService weatherService) 
        {
            _service = weatherService;
        }

        public IActionResult Index()
        {
            WeatherViewModel weather = _service.GetWeatherAsync().Result;
            return View(weather);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
