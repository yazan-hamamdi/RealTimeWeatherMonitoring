using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subjects
{
    public class WeatherStation : ISubject
    {
        private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();
        public WeatherData State { get; private set; }

        public void Subscribe(ISubscriber subscriber)
        {
            if (subscriber == null)
                throw new ArgumentNullException(nameof(subscriber));

            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            if (subscriber == null)
                throw new ArgumentNullException(nameof(subscriber));

            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                try
                {
                    subscriber.Update(State);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Subscriber {nameof(subscriber)} failed: {ex.Message}");
                }
            }
        }

        public void UpdateWeatherData(WeatherData weatherData)
        {
            if (weatherData == null)
                throw new ArgumentNullException(nameof(weatherData));

            State = weatherData;
            Notify();
        }
    }
}
