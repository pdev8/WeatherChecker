using System;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Weather.DependencyManager;

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
            serviceCollection.AddTransient<IWeatherFetcher, WeatherFetcher>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}