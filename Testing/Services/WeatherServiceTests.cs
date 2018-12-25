using System.Net.Http;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Newtonsoft.Json;
using Services;
using Weather.Interfaces;

namespace Weather.Testing.Services
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
            
            services.AddScoped<IHttpClient, Fakes.HttpClientFake>();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IWeatherFetcher>();
            (serviceProvider.GetService<IHttpClient>() as Fakes.HttpClientFake).SendAsyncCallBack = m =>
            {
                return Task.FromResult(new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this.response))
                });
            };

            // Act
            var result = service.GetCurrentWeather("92708");

            // Assert
            Assert.AreEqual(result.Main.Temp, 59.56F);
        }

        private CurrentWeather response = new CurrentWeather
        {
            Coord = new Coord
            {
                Lon = -117.95F,
                Lat = 33.71F
            },
            Weather = new[]
            {
                new Models.Weather
                {
                    Id = 721,
                    Main = "Haze",
                    Description = "haze",
                    Icon = "50n"
                }
            },
            Base = "stations",
            Main = new Main
            {
                Temp = 59.56F,
                Pressure = 1013,
                Humidity = 98,
                Temp_min = 58.64F,
                Temp_max = 60.98F
            },
            Visibility = 11265,
            Wind = new Wind
            {
                Speed = 6.93F,
                Deg = 120
            },
            Clouds = new Clouds
            {
                All = 20
            },
            Dt = 1545717480,
            Sys = new Sys
            {
                Type = 1,
                Id = 5860,
                Message = 0.0095F,
                Country = "US",
                Sunrise = 1545749671,
                Sunset = 1545785387
            },
            Id = 420006830,
            Name = "Fountain Valley",
            Cod = 200
        };
    }
}