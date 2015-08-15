using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Review
    {
        public long ReviewId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
