using Microsoft.AspNetCore.Mvc;
using ModelsHelper.Models.News.DTO;
using ModelsHelper.Models.News.Models;
using Newtonsoft.Json;
using Repository.Context;

namespace Teste.Services
{
    public class NewsApiService
    {
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
