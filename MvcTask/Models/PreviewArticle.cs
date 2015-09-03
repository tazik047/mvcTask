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
    }
}