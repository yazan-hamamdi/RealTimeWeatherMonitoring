using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SnowBot : BaseBot<SnowBotConfig>
    {
        public SnowBot(SnowBotConfig config) : base(config) { }

        public override void Update(WeatherData weatherData)
        {
            if (Enabled && weatherData.Temperature <= _config.TemperatureThreshold)
            {
                Activate();
            }
        }
    }
}
