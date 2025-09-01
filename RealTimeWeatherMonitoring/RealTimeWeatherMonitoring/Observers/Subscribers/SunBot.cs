using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SunBot : BaseBot<SunBotConfig>
    {
        public SunBot(SunBotConfig config) : base(config) { }

        public override void Update(WeatherData weatherData)
        {
            if (weatherData == null)
                throw new ArgumentNullException(nameof(weatherData));

            if (Enabled && weatherData.Temperature >= _config.TemperatureThreshold)
            {
                Activate();
            }
        }
    }
}
