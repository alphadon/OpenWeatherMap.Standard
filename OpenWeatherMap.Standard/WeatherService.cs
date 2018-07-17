using System;
using System.Threading.Tasks;
using OpenWeatherMap.Standard.Extensions;

namespace OpenWeatherMap.Standard
{
    public class WeatherService
    {
        IRestService service = null;
        public WeatherService(IRestService rest)
        {
            service = rest;
        }

        public WeatherService()
        {
            service = new RestServiceCaller();
        }

        private string GetCurrentWeatherByZipUrl(string appId, string zipCode, string countryCode, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&appid={appId}&units={units.AsUrlParameterValue()}";
        }

        private string GetCurrentWeatherByCityNameUrl(string appId, string cityName, string countryCode, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryCode}&appid={appId}&units={units.AsUrlParameterValue()}";
        }

        private string GetCurrentWeatherByCityIdUrl(string appId, int cityId, WeatherUnits units)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={appId}&units={units.AsUrlParameterValue()}";
        }

        public async Task<CurrentWeather> GetCurrentWeatherByZipAsync(string appId, string zipCode, string countryCode = "us", WeatherUnits units = WeatherUnits.Imperial)
        {
            CurrentWeather weather = null;
            try
            {
                string url = GetCurrentWeatherByZipUrl(appId, zipCode, countryCode, units);
                weather = await service.GetCurrentWeatherAsync(url);
                weather.Units = units;
                weather.CountryCode = countryCode;
            }
            catch(Exception ex)
            {
                weather = null;
            }

            return weather;
        }

        public async Task<CurrentWeather> GetCurrentWeatherByCityNameAsync(string appId, string cityName, string countryCode = "us", WeatherUnits units = WeatherUnits.Imperial)
        {
            CurrentWeather weather = null;
            try
            {
                string url = GetCurrentWeatherByCityNameUrl(appId, cityName, countryCode, units);
                weather = await service.GetCurrentWeatherAsync(url);
                weather.Units = units;
                weather.CountryCode = countryCode;
            }
            catch(Exception ex)
            {
                weather = null;
            }

            return weather;
        }

        public async Task<CurrentWeather> GetCurrentWeatherByCityIdAsync(string appId, int cityId, WeatherUnits units = WeatherUnits.Imperial)
        {
            CurrentWeather weather = null;
            try
            {
                string url = GetCurrentWeatherByCityIdUrl(appId, cityId, units);
                weather = await service.GetCurrentWeatherAsync(url);
                weather.Units = units;
            }
            catch
            {
                weather = null;
            }

            return weather;
        }
    }
}
