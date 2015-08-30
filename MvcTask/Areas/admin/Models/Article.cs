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
        private List<long> selectedIds;
        private List<DAO.Model.Tag> tags;

        public DAO.Model.Article OriginArticle
        {
            get
            {
                var a = new DAO.Model.Article();
                a.ArticleId = ArticleId;
                a.Date = Date;
                a.Title = Title;
                a.Text = Text;
                a.Tags = GetTags();
                return a;
            }
        }

        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        //public List<SelectListItem> Tags { get; set; }
        public List<SelectListItem> Tags
        {
            get
            {
                var items = tags.Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString() });
                foreach (var i in items)
                {
                    i.Selected = selectedIds.Contains(Convert.ToInt64(i.Value));
                }
                return items.ToList();
            }
        }

        public Article()
        {

        }

        public Article(DAO.Model.Article article, IEnumerable<DAO.Model.Tag> tags)
        {
            ArticleId = article.ArticleId;
            Date = article.Date;
            Title = article.Title;
            Text = article.Text;
            this.tags = tags.ToList();
            //Tags = article.Tags.Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString(), Selected = true }).ToList();
            selectedIds = article.Tags.Select(t => t.TagId).ToList();
            /*foreach (var t in tags.Where(t=>!ids.Contains(t.TagId)))
            {
                Tags.Add(new SelectListItem { Text = t.Title, Value = t.TagId.ToString(), Selected = true });
            }*/
        }

        public ICollection<DAO.Model.Tag> GetTags()
        {
            return Tags.Where(t => t.Selected)
                .Select(t => new DAO.Model.Tag { TagId = Convert.ToInt64(t.Value), Title = t.Text })
                .ToList();
        }


    }
}