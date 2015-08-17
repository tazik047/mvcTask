using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.Model;

namespace MvcTask.Models
{
    public class Article
    {
        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual List<Tag> Tags { get; set; }

        public Article(DAO.Model.Article article)
        {
            if (article == null) return;
            ArticleId = article.ArticleId;
            Date = article.Date;
            Title = article.Title;
            Text = article.Text;
            Tags = article.Taxonomies.Select(t => t.Tag).ToList();
        }
    }
}