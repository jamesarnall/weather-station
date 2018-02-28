using System;

namespace WeatherStation.Models
{

    /// <summary>
    /// DTO that strongly types results from the Sunrise Sunset API
    /// </summary>
    public class Result
    {
        public string   astronomical_twilight_begin { get; set; }
        public string   astronomical_twilight_end   { get; set; }
        public string   civil_twilight_begin        { get; set; }
        public string   civil_twilight_end          { get; set; }
        public string   day_length                  { get; set; }
        public string   nautical_twilight_begin     { get; set; }
        public string   nautical_twilight_end       { get; set; }
        public string   solar_noon                  { get; set; }
        public DateTime sunrise                     { get; set; }
        public DateTime sunset                      { get; set; }
    }

    /// <summary>
    /// DTO that strongly types results from the Sunrise Sunset API
    /// </summary>
    public class SunriseSunsetResult
    {
        public Result  results { get; set; }
        public string  status  { get; set; }
    }
}