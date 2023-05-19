using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;
using System.Text;
using WeatherApp.Properties;

namespace WeatherApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод поиска по городу и вывод информации
        private void GetWeather()
        {
            try
            {
                var info = WeatherHelper.GetWeatherInfo(txtSearch.Text);

                // Вывод температуры, описания и скорости ветра
                pictureIcon.Source = new BitmapImage(new Uri($"https://openweathermap.org/img/w/{info.weather[0].icon}.png"));
                inform.Text = info.ToString();

                // Вывод текущей даты
                dateTime.Text = $"Дата и время: {DateTime.Now}";
            }
            catch
            {
                pictureIcon.Source = null;
                dateTime.Text = string.Empty;
                inform.Text = "Такого города не существует";
            }
        }

        // Очистка поиска
        private void txtSearch_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textSearch.Text = string.Empty;
        }

        // Поиск при нажатии Enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GetWeather();
            }
        }

        // Кнопка поиска
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetWeather();
        }
    }
}
