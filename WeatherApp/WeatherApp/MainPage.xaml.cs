using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnGetWeather.Clicked += btnGetWeather_Click;
        }
        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(edtZipCode.Text))
            {
                Weather weather = await Core.GetWeather(edtZipCode.Text);

                if (weather != null)
                {
                    txtLocation.Text = weather.Title;
                    txtTemperature.Text = weather.Temperature;
                    txtWind.Text = weather.Wind;
                    txtVisibility.Text = weather.Visibility;
                    txtHumidity.Text = weather.Humidity;
                    txtSunrise.Text = weather.Sunrise;
                    txtSunset.Text = weather.Sunset;

                    btnGetWeather.Text = "Search Again";
                }
            }
        }
    }
}
