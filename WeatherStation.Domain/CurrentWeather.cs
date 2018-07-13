namespace WeatherStation.Domain
{
    public class CurrentWeather
    {
        public string ConditionsDesc  { get; set; }
        public string ConditionsLabel { get; set; }
        public string CurrentDate     { get; set; }
        public string CurrentTime     { get; set; }
        public string DayOrNight      { get; set; }
        public string FeelsLike       { get; set; }
        public string Temperature     { get; set; }
    }
}