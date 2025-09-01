using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class RainBot : BaseBot<RainBotConfig>
    {
        public RainBot(RainBotConfig config) : base(config) { }

        public override void Update(WeatherData weatherData)
        {
            if (Enabled && weatherData.Humidity >= _config.HumidityThreshold)
            {
                Activate();
            }
        }
    }
}
