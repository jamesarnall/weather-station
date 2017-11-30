using DarkSkyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace dotnet.Models
{
    public class Weather
    {
        public string ConditionsDesc { get; set; }
        public string ConditionsIcon { get; set; }
        public string DatetimeAmPm   { get; set; }
        public string DatetimeDate   { get; set; }
        public string DatetimeTime   { get; set; }
        public string Temperature    { get; set; }

        //
        public Weather(Forecast forecast)
        {
            var cur        = forecast.Currently;
            var localTime  = cur.Time.AddHours(forecast.TimeZoneOffset);
            ConditionsDesc = cur.Summary.ToString();
            ConditionsIcon = "icon--" + cur.Icon;
            DatetimeAmPm   = localTime.ToString("tt");
            DatetimeDate   = localTime.ToString("MMMM d");
            DatetimeTime   = localTime.ToString("h:mm");
            Temperature    = Math.Round(cur.Temperature).ToString();
        }
    }
}