using Microsoft.Extensions.Configuration;
using RealTimeWeatherMonitoring.DTOs;

namespace RealTimeWeatherMonitoring.Utilities
{
    public static class ConfigLoader
    {
        public static BotsConfig Load(string path = "appsettings.json")
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, optional: false, reloadOnChange: true)
                .Build();

            return configuration.GetSection("Bots").Get<BotsConfig>() ?? new BotsConfig();
        }
    }
}
