using RealTimeWeatherMonitoring.DTOs;
using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Observers.Subscribers;

namespace RealTimeWeatherMonitoring.Factories
{
    public static class BotFactory
    {
        public static IEnumerable<ISubscriber> CreateBots(BotsConfig config)
        {
            var bots = new List<ISubscriber>();

            if (config.RainBot.Enabled)
                bots.Add(new RainBot(config.RainBot));

            if (config.SunBot.Enabled)
                bots.Add(new SunBot(config.SunBot));

            if (config.SnowBot.Enabled)
                bots.Add(new SnowBot(config.SnowBot));

            return bots;
        }
    }
}
