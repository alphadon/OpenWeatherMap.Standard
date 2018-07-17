using System;
using Newtonsoft.Json;

namespace OpenWeatherMap.Standard
{
    [JsonObject("sys")]
    public class System
    {
        public int type { get; set; }

        public int id { get; set; }

        public float message { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }

        [JsonProperty("sunrise")]
        public int SunriseUnixUtc { get; set; }

        [JsonProperty("sunset")]
        public int SunsetUnixUtc { get; set; }

        public DateTime SunriseUtc
        {
            get
            {
                if (SunriseUnixUtc > 0)
                {
                    return DateTimeOffset.FromUnixTimeSeconds(SunriseUnixUtc).UtcDateTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public DateTime SunsetUtc
        {
            get
            {
                if (SunsetUnixUtc > 0)
                {
                    return DateTimeOffset.FromUnixTimeSeconds(SunsetUnixUtc).UtcDateTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public TimeSpan DayLength
        {
            get
            {
                if (SunriseUtc != DateTime.MinValue &&
                    SunsetUtc != DateTime.MinValue)
                    return (SunsetUtc - SunriseUtc);
                else
                    return TimeSpan.MinValue;
            }
        }
    }
}
