using RealTimeWeatherMonitoring.Interfaces;

namespace RealTimeWeatherMonitoring.Models
{
    public class BotConfig : IBotConfig
    {
        public bool Enabled { get; set; }
        public string Message { get; set; } = "";
    }
}
