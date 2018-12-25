using System;
using Interfaces;

namespace Weather.DependencyManager
{
    public class App
    {
        private readonly IWeatherFetcher weatherService;

        public App(
            IWeatherFetcher weatherService
        ) 
        {
            this.weatherService = weatherService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the weather app!\n");
            Console.Write("Enter a zip to find weather details: ");
            
            var zipCode = Console.ReadLine();

            var currentWeather = this.weatherService.GetCurrentWeather(zipCode);

            Console.WriteLine($"The temp in {currentWeather.Name} is {currentWeather.Main.Temp}.");
        }
    }
}