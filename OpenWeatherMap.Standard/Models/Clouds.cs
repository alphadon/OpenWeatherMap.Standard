using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int PercentCloudcover { get; set; }

        public override string ToString()
        {
            return $"{PercentCloudcover:N0} %";
        }
    }
}
