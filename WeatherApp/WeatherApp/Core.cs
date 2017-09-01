using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp;

namespace WeatherApp
{
    class Core
    {
        public static async Task<Weather> GetWeather(string pZipCode)
        {
            string key = "86e7fe12d67265a4bb37cc0e131f35bf";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + pZipCode + "us&appid=" + key + "&units=imperial";
            if (key != "86e7fe12d67265a4bb37cc0e131f35bf")
            {
                throw new ArgumentException("You must obtain an API key from" +
                    "openweathermap.org/appid and save it in the'key' variable");
            }
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
