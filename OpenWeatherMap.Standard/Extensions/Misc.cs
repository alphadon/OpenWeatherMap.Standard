using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMap.Standard.Extensions
{
    public static class Misc
    {
        public static string AsUrlParameterValue(this WeatherUnits unit)
        {
            switch (unit)
            {
                case WeatherUnits.Kelvin:
                    return String.Empty;
                case WeatherUnits.Imperial:
                    return "imperial";
                case WeatherUnits.Metric:
                    return "metric";
                default:
                    return String.Empty;
            }
        }
    }
}
