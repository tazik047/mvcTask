using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Areas.admin.Models
{
    public class Article
    {
        public DAO.Model.Article OriginArticle
        {
            get
            {
                return new DAO.Model.Article
                {
                    ArticleId = ArticleId,
                    Date = Date,
                    Title = Title,
                    Text = Text
                };
            }
        }

        public long ArticleId { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Заголовок статьи")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Содержимое")]
        public string Text { get; set; }

        [Display(Name = "Теги")]
        public List<long> Tags { get; set; }

        public Article()
        {

        }

        public Article(DAO.Model.Article article)
        {
            ArticleId = article.ArticleId;
            Date = article.Date;
            Title = article.Title;
            Text = article.Text;
            Tags = article.Tags.Select(t=>t.TagId).ToList();
        }
    }
}