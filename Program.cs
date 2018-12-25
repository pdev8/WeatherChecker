using System;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the weather app!\n");
            Console.Write("Enter a zip to find weather details: ");
            
            var zipCode = Console.ReadLine();

            IWeatherFetcher wf = new WeatherFetcher();
            var currentWeather = wf.GetCurrentWeather(zipCode);

            Console.WriteLine($"The temp in {currentWeather.Name} is {currentWeather.Main.Temp}.");

            var serviceCollection = new ServiceCollection();

            Console.ReadLine();
        }
    }
}