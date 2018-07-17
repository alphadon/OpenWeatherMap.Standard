using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace OpenWeatherMap.Standard.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize and create the ReST service
            string myApiKey = "yourkeygoeshere";
            WeatherService service = new WeatherService();
            Console.WriteLine("Service initialized successfully.");

            // Get the current weather by Zip Code, use defaults (Country: US and Units:Farenheit)
            string zip = "90210";
            string countryCode = "us";
            CurrentWeather currentWeather = null;
            Task getWeather = Task.Run(async () => { currentWeather = await service.GetCurrentWeatherByZipAsync(myApiKey, zip, countryCode); });
            getWeather.Wait();
            
            Console.WriteLine($"Get current weather by Zip code result: {currentWeather}");

            // Get the current weather by city name, specify country and units.
            CurrentWeather dataCity = null;
            Task getWeatherCity = Task.Run(async () => { dataCity = await service.GetCurrentWeatherByCityNameAsync(myApiKey, "Paris", "FR", WeatherUnits.Metric); });
            getWeatherCity.Wait();
            //4151440

            Console.WriteLine($"Get current weather by city name result: {dataCity}");

            // Get the current weather by city ID, use defaults (Units:Farenheit)
            CurrentWeather dataId = null;
            Task getWeatherId = Task.Run(async () => { dataId = await service.GetCurrentWeatherByCityIdAsync(myApiKey, 4151440); });
            getWeatherId.Wait();
            
            Console.WriteLine($"Get current weather by city ID result: {dataId}");

            // Wait for any key to be pressed.
            Console.ReadLine();
        }
    }
}
