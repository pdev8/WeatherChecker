using Models;

namespace Interfaces
{
    public interface IWeatherFetcher
    {
         CurrentWeather GetCurrentWeather(string zipCode);
    }
}