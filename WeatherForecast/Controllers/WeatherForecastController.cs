using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForecast.Models;



namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IConfiguration _configuration;

        private readonly string BASE_URL;
        private readonly string API_KEY;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            BASE_URL = _configuration["WeatherApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? string.Empty;
            //_logger.LogInformation("API_KEY: {ApiKey}", API_KEY);

        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<Repository.Models.WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Repository.Models.WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}



        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            var client = new HttpClient();
            // Monta a URL corretamente com o parâmetro 'key' e 'q' (cidade)
            var url = $"{BASE_URL}/current.json?key={API_KEY}&q={city}&lang=pt";

            try
            {
                var response = await client.GetAsync(url);

                // Verifica se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var weatherResponse = JsonConvert.DeserializeObject(content);

                    // Re-serializa o objeto para um JSON formatado (legível)
                    var formattedJson = JsonConvert.SerializeObject(weatherResponse,  Newtonsoft.Json.Formatting.Indented);

                    // Retorna o JSON formatado
                    return Ok(formattedJson);
                }
                else
                {
                    // Retorna um erro detalhado em caso de falha
                    return StatusCode((int)response.StatusCode, "Erro ao acessar a API");
                }
            }
            catch (Exception ex)
            {
                // Captura e retorna qualquer erro inesperado
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{city}/days/{days}")]
        public async Task<IActionResult> GetWeatherByCityAndDays (string city,int days)
        {
            var client = new HttpClient();
            var url = $"{BASE_URL}/forecast.json?key={API_KEY}&q={city}&days={days}&lang=pt";

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonConvert.DeserializeObject<Root>(content);


                    var root = new Root(weatherResponse);

                    var weatherForecastDto = new WeatherForecastDTO(root);
                    var forecastDayDtoList = root.forecast.forecastday.Select(fd => new ForecastDayDTO(fd)).ToList();

                    var weather = new Repository.Models.WeatherForecast(weatherForecastDto);
                    var forecastDays = new Repository.Models.ForecastDay(forecastDayDtoList);
                    
                    var formattedJson = JsonConvert.SerializeObject(weatherResponse, Newtonsoft.Json.Formatting.Indented);
                    
                    
                    return Ok(formattedJson);
                }

                return StatusCode((int)response.StatusCode, "Erro ao acessar a API");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }

        }

    }


}