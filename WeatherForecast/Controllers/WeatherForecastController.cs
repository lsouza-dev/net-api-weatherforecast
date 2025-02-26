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
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly WeatherContext _context;
        private readonly string BASE_URL;
        private readonly string API_KEY;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, WeatherContext context)
        {
            _logger = logger;
            _configuration = configuration;
            BASE_URL = _configuration["WeatherApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? string.Empty;
            _context = context;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            try
            {
                var client = new HttpClient();
                var url = $"{BASE_URL}/forecast.json?key={API_KEY}&q={city}&lang=pt";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Erro ao acessar a API");

                var content = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(content);
                if (root == null) return StatusCode(500, "Erro de deserialização dos dados da API.");

                var weatherDto = new WeatherForecastDTO(root);

                return Ok(new
                {
                    Mensagem = "Dados meteorológicos atuais",
                    Dados = weatherDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{city}/days-interval/{days}")]
        public async Task<IActionResult> GetWeatherByCityAndDays(string city, int days)
        {
            try
            {
                var client = new HttpClient();
                var url = $"{BASE_URL}/forecast.json?key={API_KEY}&q={city}&days={days}&lang=pt";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Erro ao acessar a API");

                var content = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(content);
                if (root == null) return StatusCode(500, "Erro de deserialização dos dados da API.");

                var weatherForecastDto = new WeatherForecastDTO(root);
                var weather = new WeatherForecast(weatherForecastDto);

                _context.Weathers.Add(weather);
                _context.ForecastsDays.AddRange(weather.Forecasts);
                _context.SaveChanges();

                return Ok(new
                {
                    Mensagem = $"Previsão do tempo para os próximos {days} dias",
                    Dados = weatherForecastDto
                });
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
                var forecasts = _context.ForecastsDays
                    .Where(x => x.Data.Day == day && x.WeatherForecast.Cidade == city)
                    .ToList();

                if (!forecasts.Any())
                    return NoContent(   );

                var forecastsDtos = forecasts.Select(f => new ForecastDayExibicaoDTO(f));

                return Ok(new
                {
                    Mensagem = $"Previsão do tempo para o dia {day}",
                    Dados = forecastsDtos
                });
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
                var weather = _context.Weathers.FirstOrDefault(x =>
                    x.Cidade == city && x.DataLocal.Day == now.Day && x.DataLocal.Hour == now.Hour);

                string mensagem = "Clima normal.";

                if (weather == null)
                {
                    var client = new HttpClient();
                    var url = $"{BASE_URL}/forecast.json?key={API_KEY}&q={city}&hour={now.Hour}&day=1z&lang=pt";
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                        return StatusCode((int)response.StatusCode, "Erro ao acessar a API.");

                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<Root>(content);

                    if (root == null)
                        return StatusCode(500, "Erro de deserialização dos dados da API.");

                    var weatherDto = new WeatherForecastDTO(root);
                    weather = new WeatherForecast(weatherDto);

                    _context.Weathers.Add(weather);
                    _context.SaveChanges();
                }

                if (weather.TempC > 35)
                    mensagem = "Alerta: A temperatura está acima de 35ºC, passe um protetor e beba bastante água.";
                else if (weather.TempC < 10)
                    mensagem = "Alerta: A temperatura está abaixo de 10ºC, se for sair de casa, não esqueça seu agasalho.";

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

        [HttpGet("{city}/week")]
        public async Task<IActionResult> GetWeatherByCityAndWeek(string city)
        {
            return await GetWeatherByCityAndDays(city, 7);
        }
    }
}
