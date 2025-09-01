using RealTimeWeatherMonitoring.Factories;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Utilities;

namespace RealTimeWeatherMonitoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Weather Monitoring Test...");

            var botsConfig = ConfigLoader.Load();
            var bots = BotFactory.CreateBots(botsConfig);

            var testWeatherData = new WeatherData
            {
                Temperature = 32, 
                Humidity = 75     
            };

            Console.WriteLine("\n--- Simulating Weather Update ---\n");

            foreach (var bot in bots)
            {
                bot.Update(testWeatherData);
            }

            Console.WriteLine("\nTest completed.");
            Console.ReadLine(); 
        }
    }
}
