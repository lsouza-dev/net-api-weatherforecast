using System.Globalization;
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

        [HttpGet("{city}/days-interval/{days}")]
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
                    
                    var root = JsonConvert.DeserializeObject<Root>(content);

                    var weatherForecastDto = new WeatherForecastDTO(root);
                    var weather = new WeatherForecast(weatherForecastDto);

                    _context.Weathers.Add(weather);

                    foreach (var f in weather.Forecasts)
                    {
                        _context.ForecastsDays.Add(f);
                    }

                    _context.SaveChanges();

                    Console.WriteLine($"Forecasts: {weather.Forecasts.Count}");

                    var formattedJson = JsonConvert.SerializeObject(root, Newtonsoft.Json.Formatting.Indented);


                    return Ok(formattedJson);
                }

                return StatusCode((int)response.StatusCode, "Erro ao acessar a API");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }

        }


        [HttpGet("{city}/day/{day}")]
        public ActionResult GetWeatherByCityAtDay(string city, int day)
        {
            try
            {
                var forecasts = _context.ForecastsDays.Where(x => x.Data.Day == day && x.WeatherForecast.Cidade == city).ToList();
                if (forecasts == null) return NotFound($"Não foram encontrados registros de clima para a cidade {city} no dia {day}");

                var forecastsDtos = forecasts.Select(f => new ForecastDayExibicaoDTO(f));

                return Ok(forecastsDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        [HttpGet("{city}/now")]
        public async Task<IActionResult> GetWeatherNow(string city)
        {
            try
            {
                var now = DateTime.Now;
                var weather = _context.Weathers.FirstOrDefault(x => x.Cidade == city && x.DataLocal.Day == now.Day && x.DataLocal.Hour == now.Hour);
                string mensagem = "Clima normal.";

                if (weather == null)
                {
                    var client = new HttpClient();
                    var url = $"{BASE_URL}/forecast.json?key={API_KEY}&q={city}&hour={now.Hour}&day=1z&lang=pt";
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        return StatusCode((int)response.StatusCode, "Erro ao acessar a API.");
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<Root>(content);

                    if (root == null)
                    {
                        return StatusCode(500, "Erro de deserialização dos dados da API.");
                    }

                    var weatherDto = new WeatherForecastDTO(root);

                    weather = new WeatherForecast(weatherDto);

                    _context.Weathers.Add(weather);
                    _context.SaveChanges();

                }
                
                if (weather != null)
                {
                    if (weather.TempC > 35)
                        mensagem = "Alerta: A temperatura está acima de 35ºC, passe um protetor e beba bastante água.";
                    else if (weather.TempC < 10)
                        mensagem = "Alerta: A temperatura está abaixo de 10ºC, se for sair de casa, não esqueça seu agasalho.";

                }

                return Ok(new
                {
                    Mensagem = mensagem,
                    Dados = new WeatherForecastExibicaoDTO(weather)
                });


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}