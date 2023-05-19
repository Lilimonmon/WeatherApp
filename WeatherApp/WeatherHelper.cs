using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WeatherApp.Properties;

namespace WeatherApp
{
    internal static class WeatherHelper
    {
       /// <summary>
       /// Получение информации о погоде по названию города
       /// </summary>
        public static WeatherInfo GetWeatherInfo(string cityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&lang=ru&appid={1}", cityName, Settings.Default.key);
                var json = web.DownloadString(url);
                byte[] arrByte = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(arrByte);
                return JsonConvert.DeserializeObject<WeatherInfo>(json);
            }
        }
    }
}
