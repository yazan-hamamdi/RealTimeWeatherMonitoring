using RealTimeWeatherMonitoring.Models;
using System.Text.Json;

namespace RealTimeWeatherMonitoring.Utilities
{
    public static class ConfigLoader
    {
        public static BotsConfig Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<BotsConfig>(json)
                   ?? new BotsConfig();
        }
    }
}
