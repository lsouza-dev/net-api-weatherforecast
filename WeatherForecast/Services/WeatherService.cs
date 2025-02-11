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
        private readonly string BASE_URL;
        private readonly string API_KEY;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BASE_URL = _configuration["WeatherApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? string.Empty;
        }
        public async Task<string?> GetWeatherData(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City cannot be empty", nameof(city));
            }

            var response = await _httpClient.GetAsync($"{BASE_URL}?key={API_KEY}&q={city}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;

            // Se a resposta for HTML (erro inesperado da API), retorna null
            if (contentType != null && contentType.Contains("text/html"))
            {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }


    }
}