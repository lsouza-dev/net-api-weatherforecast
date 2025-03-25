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
        public string nome;
        public string autor;
        public string titulo;
        public string descricao;
        public string url;
        public string urlImagem;
        public DateTime dataDePublicacao;
        public string conteudo;

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

        }

        public override string ToString()
        {
            return $"""
                Source: {nome},Author: {autor},Title: {titulo},Description: {descricao},Url: {url},UrlImage: {urlImagem},Published: {dataDePublicacao},Content: {conteudo}
                """;
        }
    }
}
