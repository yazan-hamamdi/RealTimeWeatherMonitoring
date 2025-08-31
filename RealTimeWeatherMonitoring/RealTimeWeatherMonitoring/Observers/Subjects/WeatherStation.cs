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
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(State);
            }
        }

        public void UpdateWeatherData(WeatherData weatherData)
        {
            State = weatherData;
            Notify();
        }

    }
}
