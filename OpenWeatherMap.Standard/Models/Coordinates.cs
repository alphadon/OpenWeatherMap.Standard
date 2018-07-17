using System;
using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    [JsonObject("coord")]
    public class Coordinates
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }

        public override string ToString()
        {
            if (Math.Abs(Latitude) > 0 || Math.Abs(Longitude) > 0)
                return $"{Latitude}, {Longitude}";
            else
                return base.ToString();
        }
    }
}
