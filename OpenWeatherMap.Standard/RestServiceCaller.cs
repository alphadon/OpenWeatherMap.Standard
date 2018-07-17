using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard
{
    class RestServiceCaller : IRestService
    {
        HttpClient http = new HttpClient();

        public async Task<CurrentWeather> GetCurrentWeatherAsync(string url)
        {
            CurrentWeather weather = null;

            HttpClient http = new HttpClient();
            string json = "";
            json = await http.GetStringAsync(url);
            weather = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentWeather>(json);

            return weather;
        }
    }
}
