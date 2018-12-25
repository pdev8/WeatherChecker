using System;
using System.Net.Http;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Weather.DependencyManager;
using Weather.Interfaces;
using Weather.Services;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run();

            Console.ReadLine();
        }

        static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add services
            var httpClient = new HttpClientWrapper(new HttpClientHandler { UseCookies = false });
            serviceCollection.AddSingleton<IHttpClient>(httpClient);
            serviceCollection.AddTransient<IWeatherFetcher, WeatherFetcher>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}