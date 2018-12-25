using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace Weather.Testing
{
    [TestClass]
    public class WeatherServiceTests
    {
        [TestMethod]
        public void WeatherFetcher_GetCurrentWeather_Should_Return_Successful_Weather()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddTransient<IWeatherFetcher, WeatherFetcher>();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IWeatherFetcher>();

            // Act
        }
    }
}
