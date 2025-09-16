using RealTimeWeatherMonitoring.DTOs;

namespace RealTimeWeatherMonitoring.Test.TestDoubles
{
    public class TestRainBotConfig : RainBotConfig
    {
        public TestRainBotConfig(bool enabled, int humidityThreshold)
        {
            Enabled = enabled;
            HumidityThreshold = humidityThreshold;
        }
    }
}
