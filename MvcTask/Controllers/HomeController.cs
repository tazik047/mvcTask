using MvcTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = new List<Article>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Article()
                {
                    Title = "Заголовок " + i,
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec id accumsan lacus. Aliquam viverra eros vitae turpis viverra, vitae semper sem elementum. Fusce ante nulla, viverra vel blandit ut, consequat ac diam. Donec ut consectetur sapien. Donec nisi sapien, molestie ut ornare in, elementum id est. Morbi volutpat pulvinar ipsum. Nam nunc nibh, bibendum id tortor a, placerat tincidunt elit. Nunc tempus ipsum nec velit pellentesque, sed gravida orci ullamcorper. Nunc porttitor purus nibh, eget vulputate ligula ornare vitae.",
                    Date = DateTime.Now
                });
            }
            return View(list);
        }

    }
}
