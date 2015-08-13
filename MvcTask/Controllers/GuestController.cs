using MvcTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Controllers
{
    public class GuestController : Controller
    {
        //
        // GET: /Guest/

        public ActionResult Index()
        {
            var list = new List<Review>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Review()
                {
                    Name = "Имя " + i,
                    Date = DateTime.Now,
                    Text = "Отличный сайт. Нашел здесь именно то, что искал."
                });
            }
            ViewBag.Reviews = list;
            return View();
        }

        [HttpPost]
        public ActionResult Registration(string name, DateTime date, string review)
        {
            ViewBag.Name = name;
            return View();
        }

    }
}
