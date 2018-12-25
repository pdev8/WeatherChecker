using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Weather.Interfaces;

namespace Services
{
    public class WeatherFetcher : IWeatherFetcher
    {
        private readonly IHttpClient client;
        private const string ApiUrl = "http://api.openweathermap.org/";
        private const string ApiKey = "62f806f056187436b4dcf3684138c2e6";

        public WeatherFetcher(
            IHttpClient client)
        {
            this.client = client;
        }

        public CurrentWeather GetCurrentWeather(string zipCode)
        {
            var requestMessage = BuildRequestMessage(zipCode);

            var responseMessage = this.client.SendAsync(requestMessage).GetAwaiter().GetResult();

            var response = ParseResponse(responseMessage).GetAwaiter().GetResult();

            return response;
        }

        private static HttpRequestMessage BuildRequestMessage(string zipCode)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{ApiUrl}data/2.5/weather?zip={zipCode}&units=imperial&appid={ApiKey}")
            };

            requestMessage.Headers.Add("Accept", "application/json");

            return requestMessage;
        }

        private static async Task<CurrentWeather> ParseResponse(HttpResponseMessage responseMessage)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.DeserializeObject<CurrentWeather>(responseString, settings); 
        }
    }
}