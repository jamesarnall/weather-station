
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace WeatherStation.Models
{
    /// <summary>
    /// DTO for data retrieved from the Dark Sky API
    /// </summary>
    /// <comments>
    /// Refer to https://darksky.net/dev/docs
    /// </comments>
    public class DarkSkyResult
    {
        public List<Alert> Alerts    { get; set; }
        public DataPoint   Currently { get; set; }
        public DataBlock   Daily     { get; set; }
        public FlagsObject Flags     { get; set; }
        public DataBlock   Hourly    { get; set; }
        public double      Latitude  { get; set; } // REQUIRED
        public double      Longitude { get; set; } // REQUIRED
        public DataBlock   Minutely  { get; set; }
        public int         Offset    { get; set; } // *DEPRECATED*
        public string      Timezone  { get; set; } // REQUIRED
    }

    /// <summary>
    /// Individual set of data for a forecast or observation
    /// </summary>
    public class DataPoint
    {
        public double   ApparentTemperature         { get; set; } // optional, not on daily
        public double   ApparentTemperatureHigh     { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ApparentTemperatureHighTime { get; set; } // optional, only on daily

        public double   ApparentTemperatureLow      { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ApparentTemperatureLowTime  { get; set; } // optional, only on daily

        public double   ApparentTemperatureMax      { get; set; } // optional, only on daily *DEPRECATED*

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ApparentTemperatureMaxTime  { get; set; } // optional, only on daily *DEPRECATED*

        public double   ApparentTemperatureMin      { get; set; } // optional, only on daily *DEPRECATED*

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ApparentTemperatureMinTime  { get; set; } // optional, only on daily *DEPRECATED*

        public double   Cloudcover                  { get; set; } // optional
        public double   DewPoint                    { get; set; } // optional
        public double   Humidity                    { get; set; } // optional
        public string   Icon                        { get; set; } // optional
        public double   MoonPhase                   { get; set; } // optional, only on daily
        public int      NearestStormBearing         { get; set; } // optional, only on currently
        public int      NearestStormDistance        { get; set; } // optional, only on currently
        public double   Ozone                       { get; set; } // optional
        public double   PrecipAccumulation          { get; set; } // optional, only on hourly and daily
        public double   PrecipIntensity             { get; set; } // optional
        public double   PrecipIntensityMax          { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime PrecipIntensityMaxTime      { get; set; } // optional, only on daily

        public double   PrecipProbability           { get; set; } // optional
        public string   PrecipType                  { get; set; } // optional
        public double   Pressure                    { get; set; } // optional
        public string   Summary                     { get; set; } // optional

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime SunriseTime                 { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime SunsetTime                  { get; set; } // optional, only on daily

        public double   Temperature                 { get; set; } // optional, not on minutely
        public double   TemperatureHigh             { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TemperatureHighTime         { get; set; } // optional, only on daily

        public double   TemperatureLow              { get; set; } // optional, only on daily

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TemperatureLowTime          { get; set; } // optional, only on daily

        public double   TemperatureMax              { get; set; } // optional, only on daily *DEPRECATED*

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TemperatureMaxTime          { get; set; } // optional, only on daily *DEPRECATED*

        public double   TemperatureMin              { get; set; } // optional, only on daily *DEPRECATED*

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime TemperatureMinTime          { get; set; } // optional, only on daily *DEPRECATED*

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time                        { get; set; } // REQUIRED

        public int      UvIndex                     { get; set; } // optional

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime UvIndexTime                 { get; set; } // optional, only on daily

        public double   Visibility                  { get; set; } // optional
        public int      WindBearing                 { get; set; } // optional
        public double   WindGust                    { get; set; } // optional
        public double   WindSpeed                   { get; set; } // optional
    }

    /// <summary>
    /// Collection of data observations or forecasts
    /// </summary>
    public class DataBlock 
    {
        public List<DataPoint> Data    { get; set; } // REQUIRED
        public string          Icon    { get; set; }
        public string          Summary { get; set; }
    }

    /// <summary>
    /// Various metadata information related to the request
    /// </summary>
    public class FlagsObject
    {
        public string       DarkskyUnavailable { get; set; }
        public List<string> Sources            { get; set; } // REQUIRED
        public string       Units              { get; set; } // REQUIRED
    }

    /// <summary>
    /// Represents a severe weather warning issued for the requested location by a governmental authority 
    /// </summary>
    public class Alert
    {
        public string       Description { get; set; } // REQUIRED
        
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime     Expires     { get; set; } // REQUIRED
        
        public List<string> Regions     { get; set; } // REQUIRED
        public string       Severity    { get; set; } // REQUIRED
        
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime     Time        { get; set; } // REQUIRED
        
        public string       Title       { get; set; } // REQUIRED
        public string       Uri         { get; set; } // REQUIRED
    }
}
