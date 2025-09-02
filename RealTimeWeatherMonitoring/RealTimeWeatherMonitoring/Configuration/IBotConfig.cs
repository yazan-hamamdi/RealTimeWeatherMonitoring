namespace RealTimeWeatherMonitoring.DTOs
{
    public interface IBotConfig
    {
        bool Enabled { get; set; }
        string Message { get; set; }
    }
}