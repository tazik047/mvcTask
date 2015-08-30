//using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTask.Models
{
    public class PreviewArticle
    {
        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public PreviewArticle()
        {
            
        }

        public PreviewArticle(DAO.Model.Article article)
        {
            ArticleId = article.ArticleId;
            Date = article.Date;
            Title = article.Title;
            Text = new string(article.Text.Take(200).ToArray()) + (article.Text.Length > 200 ? "..." : "");
        }
    }
}