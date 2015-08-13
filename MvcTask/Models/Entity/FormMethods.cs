using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTask.Models.Entity
{
    public partial class Form
    {
        public List<string> AdditionInformation
        {
            get
            {
                var list = new List<string>();
                if (Married) list.Add("Замужем/Женат");
                if (Animals) list.Add("Есть домашние животные");
                if (Childs) list.Add("Есть дети");
                return list;
            }
        }
    }
}