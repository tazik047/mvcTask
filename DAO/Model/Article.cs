using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Article
    {
        public long ArticleId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
