using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class Form
    {
        public long FormId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public bool Married { get; set; }
        public bool Animals { get; set; }
        public bool Childs { get; set; }
        public string Name { get; set; }
    }
}
