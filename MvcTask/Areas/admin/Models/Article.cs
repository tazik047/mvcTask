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
                var a = new DAO.Model.Article();
                a.ArticleId = ArticleId;
                a.Date = Date;
                a.Title = Title;
                a.Text = Text;
                return a;
            }
        }

        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        //public List<DAO.Model.Tag> Tags { get; set; }
        public List<long> Tags { get; set; }
        /*public List<SelectListItem> Tags
        {
            get
            {
                var items = tags.Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString() }).ToList();
                for (int i = 0; i < items.Count; i++ )
                {
                    if (selectedIds.Contains(Convert.ToInt64(items[i].Value)))
                        items[i].Selected = true;
                }
                return items;
            }
        }*/

        public Article()
        {

        }

        public Article(DAO.Model.Article article)
        {
            ArticleId = article.ArticleId;
            Date = article.Date;
            Title = article.Title;
            Text = article.Text;
            Tags = article.Tags.Select(t=>t.TagId).ToList();//.Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString(), Selected = true }).ToList();
            //selectedIds = article.Tags.Select(t => t.TagId).ToList();
            /*foreach (var t in tags.Where(t=>!ids.Contains(t.TagId)))
            {
                Tags.Add(new SelectListItem { Text = t.Title, Value = t.TagId.ToString(), Selected = true });
            }*/
        }
    }
}