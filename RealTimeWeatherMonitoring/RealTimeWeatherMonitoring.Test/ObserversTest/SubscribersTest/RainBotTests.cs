using FluentAssertions;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Test.TestDoubles;

namespace RealTimeWeatherMonitoring.Test.ObserversTest.SubscribersTest
{
    public class RainBotTests
    {
        [Fact]
        public void Update_WeatherDataIsNull_ThrowsArgumentNullException()
        {
            var config = new TestRainBotConfig(true, 70);
            var bot = new TestRainBot(config);

            Action act = () => bot.Update(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Update_BotEnabledAndHumidityAboveThreshold_Activates()
        {
            var config = new TestRainBotConfig(true, 60);
            var bot = new TestRainBot(config);
            var weather = new WeatherData { Humidity = 80 };

            bot.Update(weather);

            bot.Activated.Should().BeTrue();
        }

        [Fact]
        public void Update_BotEnabledAndHumidityBelowThreshold_DoesNotActivate()
        {
            var config = new TestRainBotConfig(true, 90);
            var bot = new TestRainBot(config);
            var weather = new WeatherData { Humidity = 50 };

            bot.Update(weather);

            bot.Activated.Should().BeFalse();
        }

        [Fact]
        public void Update_BotDisabled_DoesNotActivate()
        {
            var config = new TestRainBotConfig(false, 60);
            var bot = new TestRainBot(config);
            var weather = new WeatherData { Humidity = 80 };

            bot.Update(weather);

            bot.Activated.Should().BeFalse();
        }
    }
}
