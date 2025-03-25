using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.Context;
using ModelsHelper.Models.News.Models;
using ModelsHelper.Models.News.DTO;
using Teste.Services;

namespace Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly WeatherContext _weatherContext;
        private readonly NewsApiService _service;
        private readonly string BASE_URL;
        private readonly string API_KEY;

        public NewsApiController(IConfiguration configuration,WeatherContext weatherContext,NewsApiService service)
        {
            _configuration = configuration;
            _weatherContext = weatherContext;
            _service = service;
            BASE_URL = configuration["NewsApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("NEWS_API_KEY") ?? string.Empty;
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> GetNewsByCity(string country)
        {
            try
            {
                if (country.Length != 2) return BadRequest(new { Mensagem = "The country code needs to have 2 characters" });

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "MeuProjetoAcademico/1.0");


                var url = $"{BASE_URL}country={country}&apiKey={API_KEY}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode) return StatusCode((int)response.StatusCode, $"Erro ao acessar a API: {response.ReasonPhrase}");

                var content = await response.Content.ReadAsStringAsync();
                var articles = _service.GetNewsArticle(content);
                articles.ForEach(Console.WriteLine);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

    }

}