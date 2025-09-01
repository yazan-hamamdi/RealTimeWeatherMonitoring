namespace RealTimeWeatherMonitoring.Interfaces
{
    public interface IBotConfig
    {
        bool Enabled { get; set; }
        string Message { get; set; }
    }
}