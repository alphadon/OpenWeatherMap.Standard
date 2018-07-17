
using System;
using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    [JsonObject("weather")]
    public class CurrentWeather
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("weather")]
        public WeatherCondition[] WeatherConditions { get; set; }

        [JsonProperty("main")]
        public General General { get; set; }

        [JsonProperty("visibility")]
        public int VisibilityInMeters { get; set; }

        public int VisibilityInMiles
        {
            get { return VisibilityInMeters > 0 ? (int) Math.Round(VisibilityInMeters / 1609.34, 0, MidpointRounding.AwayFromZero) : 0; }
        }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public int DataAsOfUnixUtc { get; set; }

        [JsonIgnore]
        public DateTime DataAsOfUtc
        {
            get
            {
                if (DataAsOfUnixUtc > 0)
                    return DateTimeOffset.FromUnixTimeSeconds(DataAsOfUnixUtc).DateTime;
                else
                    return DateTime.MinValue;
            }
        }

        public System sys { get; set; }

        [JsonProperty("id")]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("cod")]
        public int ResultCode { get; set; }

        [JsonIgnore]
        public WeatherUnits Units { get; set; }

        [JsonIgnore]
        public string CountryCode { get; set; }

        public override string ToString()
        {
            if (CityId != 0)
                return $"{CityName} - {General}";
            else
                return base.ToString();
        }
    }
}
