using RealTimeWeatherMonitoring.DTOs;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Observers.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeWeatherMonitoring.Test.TestDoubles
{
    public class TestRainBot : RainBot
    {
        public bool Activated { get; private set; } = false;

        public TestRainBot(RainBotConfig config) : base(config) { }

        public override void Update(WeatherData weatherData)
        {
            if (weatherData == null)
                throw new ArgumentNullException(nameof(weatherData));

            if (Enabled && weatherData.Humidity >= _config.HumidityThreshold)
            {
                Activated = true;
            }
        }
    }

}
