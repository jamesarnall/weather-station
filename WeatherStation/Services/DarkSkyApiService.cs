
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public class DarkSkyApiService : IDarkSkyApiService 
    {

        private static readonly string _apiKey  = "c35a1260e1e4fcd3638d98ff589fdb20";
        private static readonly string _latLong = "41.9196639,-87.6408094";  // 2045 N Sedgwick St, Chicago
        private static readonly string _apiUri  = "https://api.darksky.net/forecast/" + 
                                                    _apiKey +"/" + _latLong;
        private static readonly HttpClient client = new HttpClient();

        /// <inheritdoc />
        public async Task<WeatherViewModel> GetWeatherAsync()
        {
            DarkSkyResult result = null;
            HttpResponseMessage response = await client.GetAsync(_apiUri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = GetDarkSkyResult(content);
            }

            return MapDarkSkyToWeather(result);

            // throw new NotImplementedException("DarkSkyApiService.GetWeatherDataAsync NOT IMPLEMENTED");
        }

        /// <inheritdoc />
        public DarkSkyResult GetDarkSkyResult(string jsonData)
        {
            // DarkSkyResult result = null;

            // HttpResponseMessage response = await client.GetAsync(_apiUri);
            // if (response.IsSuccessStatusCode)
            // {
            //     var content = await response.Content.ReadAsStringAsync();
            //     result = JsonConvert.DeserializeObject<DarkSkyResult>(content);
            // }
            
            // return result;

            return JsonConvert.DeserializeObject<DarkSkyResult>(jsonData);
            // throw new NotImplementedException("DarkSkyApiService.GetDarkSkyResultAsync NOT IMPLEMENTED");
        }

        /// <inheritdoc />
        public WeatherViewModel MapDarkSkyToWeather(DarkSkyResult darkSky)
        {
            var currentTime = darkSky.Currently.Time.InTimeZone(darkSky.Timezone);

            var weather = new WeatherViewModel 
            {
                ConditionsLabel = darkSky.Currently.Icon,
                ConditionsDesc  = darkSky.Currently.Summary,
                DayOrNight      = darkSky.Currently.Time.DayOrNight(darkSky.Daily.Data[0].SunsetTime),
                CurrentDate     = currentTime.ToString("dddd, MMMM d"),
                CurrentTime     = currentTime.ToString("t"),
                FeelsLike       = Math.Round(darkSky.Currently.ApparentTemperature).ToString(),
                Temperature     = Math.Round(darkSky.Currently.Temperature).ToString()
            };

            //
            return weather;
            // throw new NotImplementedException("DarkSkyApiService.MapDarkSkyToWeather NOT IMPLEMENTED");
        }
    }
}