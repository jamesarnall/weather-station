using System;
using System.Threading.Tasks;
using WeatherStation.Models;

namespace WeatherStation.Services
{
    public class WeatherService: IWeatherService 
    {
        //private readonly        string     apiUri = "https://api.sunrise-sunset.org/json?lat=41.9196694&lng=-87.6388487";
        //private readonly static HttpClient client = new HttpClient();

        ///// <inheritdoc />
        //public WeatherViewModel GetWeather() 
        //{
        //    throw new NotImplementedException("WeatherService.GetWeather NOT IMPLEMENTED");
        //}

        ///// <inheritdoc />
        //public async Task<string> GetDayOrNight(DateTime currentTime) 
        //{
        //    SunriseSunsetResult sunset = null;

        //    HttpResponseMessage response = await client.GetAsync(apiUri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        sunset = JsonConvert.DeserializeObject<SunriseSunsetResult>(content);
        //    }
            
        //    // return sunset;
        //    //
        //    throw new NotImplementedException("WeatherService.GetDayOrNight NOT IMPLEMENTED");
        //}

        ///// <inheritdoc />
        //public async Task<SunriseSunsetResult> GetSunriseSunsetResultAsync() 
        //{
        //    SunriseSunsetResult sunset = null;

        //    HttpResponseMessage response = await client.GetAsync(apiUri);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        sunset = JsonConvert.DeserializeObject<SunriseSunsetResult>(content);
        //    }
            
        //    return sunset;
        //    //
        //    // throw new NotImplementedException("WeatherService.GetDayOrNight NOT IMPLEMENTED");
        //}

        /// <inheritdoc />
        public async Task<WeatherViewModel> GetWeatherAsync() 
        {
            throw new NotImplementedException("WeatherService.GetWeatherDataAsync NOT IMPLEMENTED");
        }
    }
}
