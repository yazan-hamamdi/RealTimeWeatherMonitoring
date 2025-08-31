using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.DTOs
{
    public class BotsConfig
    {
        public RainBotConfig RainBot { get; set; } = new();
        public SunBotConfig SunBot { get; set; } = new();
        public SnowBotConfig SnowBot { get; set; } = new();
    }
}
