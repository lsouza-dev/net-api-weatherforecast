using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ModelsHelper.Models.News.Models;

namespace ModelsHelper.Models.News.DTO
{
    public record ArticleExibicaoDTO
    {
        public string nome { get; set; }
        public string autor { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string url { get; set; }
        public string urlImagem { get; set; }
        public DateTime dataDePublicacao { get; set; }
        public string conteudo { get; set; }

        public ArticleExibicaoDTO(Article art)
        {
            this.nome = art.source.name;
            this.autor = art.author;
            this.titulo = art.title;
            this.descricao = art.description;
            this.url = art.url;
            this.urlImagem = art.urlToImage;
            this.dataDePublicacao = art.publishedAt;
            this.conteudo = art.content;

            Console.WriteLine($"Article => {this.nome} \n{this}\n\n");

        }

        public override string ToString()
        {
            return $"""
                Source: {nome},Author: {autor},Title: {titulo},Description: {descricao},Url: {url},UrlImage: {urlImagem},Published: {dataDePublicacao},Content: {conteudo}
                """;
        }
    }
}
