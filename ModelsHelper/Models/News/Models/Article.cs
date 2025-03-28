﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsHelper.Models.News.Models
{
    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }

        public override string ToString()
        {
            return $"""
                Source: {source.name},Author: {author},Title: {title},Description: {description},Url: {url},UrlImage: {urlToImage},Published: {publishedAt},Content: {content}
                """;
        }
    }
}
