using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Services
{
    public class WeatherFetcher : IWeatherFetcher
    {
        private readonly HttpClient client = new HttpClient();

        public CurrentWeather GetCurrentWeather(string zipCode)
        {
            var response = RunAsync("62f806f056187436b4dcf3684138c2e6", zipCode).GetAwaiter().GetResult();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<CurrentWeather>(response, settings);
        }

        private async Task<string> RunAsync(string key, string zipCode)
        {
            client.BaseAddress = new System.Uri("http://api.openweathermap.org/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = string.Empty;

            try
            {
                result = await GetWeatherAsync(key, zipCode);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private async Task<string> GetWeatherAsync(string key, string zipCode)
        {
            var result = string.Empty;

            try
            {
                var response = await client.GetAsync($"data/2.5/weather?zip={zipCode}&units=imperial&appid={key}");

                result = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}