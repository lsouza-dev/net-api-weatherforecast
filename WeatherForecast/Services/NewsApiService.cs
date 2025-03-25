using Microsoft.AspNetCore.Mvc;
using ModelsHelper.Models.News.DTO;
using ModelsHelper.Models.News.Models;
using Newtonsoft.Json;
using Repository.Context;

namespace Teste.Services
{
    public class NewsApiService
    {
        private readonly IConfiguration _configuration;
        private readonly WeatherContext _weatherContext;
        private readonly string BASE_URL;
        private readonly string API_KEY;

        public NewsApiService(IConfiguration configuration, WeatherContext weatherContext)
        {
            _configuration = configuration;
            _weatherContext = weatherContext;
            BASE_URL = configuration["NewsApi:BaseUrl"] ?? "";
            API_KEY = Environment.GetEnvironmentVariable("NEWS_API_KEY") ?? string.Empty;
        }

        public List<ArticleExibicaoDTO> GetNewsArticle (string content)
        {
            try
            {
                var root = JsonConvert.DeserializeObject<Root>(content);
                var articles = root.articles.Select(a => new ArticleExibicaoDTO(a)).ToList();

                return articles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
