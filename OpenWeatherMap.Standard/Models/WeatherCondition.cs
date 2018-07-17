using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    [JsonObject("weather")]
    public class WeatherCondition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonIgnore]
        public string IconUrl
        {
            get
            { return !string.IsNullOrWhiteSpace(Icon) ? 
                $"http://openweathermap.org/img/w/{Icon}.png" : 
                string.Empty;
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Name))
                return $"{Name} - {Description}";
            else
                return base.ToString();
        }
    }

}
