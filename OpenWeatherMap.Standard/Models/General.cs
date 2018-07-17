using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    [JsonObject("main")]
    public class General
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min")]
        public float LowTemperature { get; set; }

        [JsonProperty("temp_max")]
        public float HighTemperature { get; set; }

        public override string ToString()
        {
            if (Pressure > 0)
            {
                return $"{Temperature}°, {Humidity}% Humidity";
            }
            else
            {
                return base.ToString();
            }
        }
    }

}
