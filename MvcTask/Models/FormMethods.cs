using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAO.Model;

namespace MvcTask.Models.Entity
{
    public static class FormMethod
    {
        public static List<string> AdditionInformation(this Form form)
        {
            var list = new List<string>();
            if (form.Married) list.Add("Замужем/Женат");
            if (form.Animals) list.Add("Есть домашние животные");
            if (form.Childs) list.Add("Есть дети");
            return list;
        }
    }
}