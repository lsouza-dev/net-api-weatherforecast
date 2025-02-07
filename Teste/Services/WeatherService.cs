using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<string> GetWeatherData(string city)
        {
            string baseUrl = _configuration["WeatherApi:BaseUrl"];
            string apiKey = _configuration["WeatherApi:ApiKey"];
            return await _httpClient.GetStringAsync($"{baseUrl}/{city}?apikey={apiKey}");
        }
    }
}