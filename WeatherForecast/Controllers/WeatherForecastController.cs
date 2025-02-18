using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsHelper.Models.Repository;
using ModelsHelper.Models.Repository.DTOS.Exibicao;
using ModelsHelper.Models.WeatherForecast;
using Newtonsoft.Json;
using Repository.Context;


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
        private readonly WeatherContext _context;

        private readonly string BASE_URL;
        private readonly string API_KEY;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration,WeatherContext context)
        {
            _logger = logger;
            _configuration = configuration;
            BASE_URL = _configuration["WeatherApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? string.Empty;
            _context = context;
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
        public async Task<IActionResult> GetWeatherByCityAndDays(string city, int days)
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
                    var forecastDayDtoList = weatherForecastDto.Forecasts;

                    var weather = new WeatherForecast(weatherForecastDto);


                    _context.Weathers.Add(weather);

                    foreach (var f in weather.Forecasts)
                    {
                        _context.ForecastsDays.Add(f);
                    }

                    _context.SaveChanges();


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


        [HttpGet("city{city}/day/{day}")]
        public ActionResult GetWeatherByCityAtDay(string city, int day)
        {
            try
            {
                var forecasts = _context.ForecastsDays.Where(x => x.Data.Day == day).Include(x => x.WeatherForecast).ToList();
                if (forecasts == null) return NotFound($"Não foram encontrados registros de clima para a cidade {city} no dia {day}");

                var forecastsDtos = forecasts.Select(f => new ForecastDayExibicaoDTO(f));

                return Ok(forecastsDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}