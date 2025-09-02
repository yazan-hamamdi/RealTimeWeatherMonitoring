using RealTimeWeatherMonitoring.Factories;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Observers.Subjects;
using RealTimeWeatherMonitoring.Utilities;

namespace RealTimeWeatherMonitoring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter weather data (JSON or XML)");
            string input = Console.ReadLine();

            try
            {
                var selector = new WeatherDataParserSelector();
                var parser = selector.SelectParser(input);

                WeatherData weatherData = parser.Parse(input);

                var config = ConfigLoader.Load();

                var bots = BotFactory.CreateBots(config);

                var station = new WeatherStation();
                foreach (var bot in bots)
                    station.Subscribe(bot);

                station.UpdateWeatherData(weatherData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
