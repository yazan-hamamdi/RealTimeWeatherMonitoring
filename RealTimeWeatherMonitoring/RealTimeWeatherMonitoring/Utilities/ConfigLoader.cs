using Microsoft.Extensions.Configuration;
using RealTimeWeatherMonitoring.DTOs;

namespace RealTimeWeatherMonitoring.Utilities
{
    public static class ConfigLoader
    {
        private const string ConfigFilePath = "appsettings.json";

        public static BotsConfig Load()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigFilePath, optional: false, reloadOnChange: true)
                .Build();

            return configuration.GetSection(ConfigKeys.BotsSection).Get<BotsConfig>() ?? new BotsConfig();
        }
    }
}
