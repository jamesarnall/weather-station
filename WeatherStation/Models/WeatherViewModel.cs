
namespace WeatherStation.Models
{
    /// <summary>
    /// Domain object that defines what we want to see on our weather page
    /// </summary>
    public class WeatherViewModel
    {
        public string ConditionsDesc  { get; set; }
        public string ConditionsLabel { get; set; }
        public string CurrentDate     { get; set; }
        public string CurrentTime     { get; set; }
        public string DayOrNight      { get; set; }
        public string FeelsLike       { get; set; }
        public string Temperature     { get; set; }

        // [JsonConverter(typeof(StringEnumConverter))]
        public string Icon 
        { 
            get 
            { 
                return SetIcon(ConditionsLabel);
            }
        }

        private static string SetIcon(string label)
        {
            return label
                    .Replace("-day", "")
                    .Replace("-night", "")
                    .Replace("-", "")
                   ;
        }
    }
}
