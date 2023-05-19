using System.Collections.Generic;

namespace WeatherApp
{
    /// <summary>
    /// Информация о погоде
    /// </summary>
    internal class WeatherInfo
    {
        /// <summary>
        /// Облачность
        /// </summary>
        public List<Weather> weather { get; set; }

        /// <summary>
        /// Температура
        /// </summary>
        public Main main { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        public Wind wind { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string name { get; set; }

        public override string ToString()
        {
            return $"Город {name}" +
                   $"\nТемпература {main.temp} °C" +
                   $"\n{char.ToUpper(weather[0].description[0]) + weather[0].description.Substring(1)}" +
                   $"\nСкорость ветра {wind.speed} м/с";
        }
    }
    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }
}
