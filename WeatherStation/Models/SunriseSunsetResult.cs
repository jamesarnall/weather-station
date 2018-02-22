using System;

namespace WeatherStation.Models
{
    /// <summary>
    /// DTO that strongly types results from the Sunrise Sunset API
    /// </summary>
    public class SunriseSunsetResult
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset  { get; set; }
    }
}