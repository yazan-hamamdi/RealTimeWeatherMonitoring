using FluentAssertions;
using Moq;
using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Observers.Subjects;

namespace RealTimeWeatherMonitoring.Test.ObserversTest.SubjectsTest
{
    public class WeatherStationTests
    {
        private readonly WeatherStation _station;

        public WeatherStationTests()
        {
            _station = new WeatherStation();
        }

        [Fact]
        public void Subscribe_SubscriberIsNull_ThrowsArgumentNullException()
        {
            // Act
            Action act = () => _station.Subscribe(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Subscribe_ValidSubscriber_AddsSubscriber()
        {
            // Arrange
            var mockSubscriber = new Mock<ISubscriber>();

            // Act
            _station.Subscribe(mockSubscriber.Object);
            _station.UpdateWeatherData(new WeatherData { Temperature = 25 });

            // Assert
            mockSubscriber.Verify(s => s.Update(It.IsAny<WeatherData>()), Times.Once);
        }

        [Fact]
        public void Unsubscribe_SubscriberIsNull_ThrowsArgumentNullException()
        {
            // Act
            Action act = () => _station.Unsubscribe(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Unsubscribe_ValidSubscriber_RemovesSubscriber()
        {
            // Arrange
            var mockSubscriber = new Mock<ISubscriber>();
            _station.Subscribe(mockSubscriber.Object);
            _station.Unsubscribe(mockSubscriber.Object);

            // Act
            _station.UpdateWeatherData(new WeatherData { Temperature = 30 });

            // Assert
            mockSubscriber.Verify(s => s.Update(It.IsAny<WeatherData>()), Times.Never);
        }

        [Fact]
        public void Notify_WithMultipleSubscribers_CallsAllSubscribers()
        {
            // Arrange
            var sub1 = new Mock<ISubscriber>();
            var sub2 = new Mock<ISubscriber>();
            _station.Subscribe(sub1.Object);
            _station.Subscribe(sub2.Object);
            var data = new WeatherData { Temperature = 20 };

            // Act
            _station.UpdateWeatherData(data);

            // Assert
            sub1.Verify(s => s.Update(data), Times.Once);
            sub2.Verify(s => s.Update(data), Times.Once);
        }

        [Fact]
        public void Notify_SubscriberThrowsException_ContinuesWithOthers()
        {
            // Arrange
            var failingSub = new Mock<ISubscriber>();
            failingSub.Setup(s => s.Update(It.IsAny<WeatherData>())).Throws(new Exception("fail"));
            var workingSub = new Mock<ISubscriber>();

            _station.Subscribe(failingSub.Object);
            _station.Subscribe(workingSub.Object);

            var data = new WeatherData { Temperature = 22 };

            // Act
            _station.UpdateWeatherData(data);

            // Assert
            workingSub.Verify(s => s.Update(data), Times.Once);
        }

        [Fact]
        public void UpdateWeatherData_DataIsNull_ThrowsArgumentNullException()
        {
            // Act
            Action act = () => _station.UpdateWeatherData(null);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateWeatherData_ValidData_UpdatesStateAndNotifies()
        {
            // Arrange
            var mockSubscriber = new Mock<ISubscriber>();
            _station.Subscribe(mockSubscriber.Object);
            var data = new WeatherData { Temperature = 28 };

            // Act
            _station.UpdateWeatherData(data);

            // Assert
            _station.State.Should().Be(data);
            mockSubscriber.Verify(s => s.Update(data), Times.Once);
        }
    }
}
