using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}