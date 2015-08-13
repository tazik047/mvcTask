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
        private Repositoriy repo = new Repositoriy();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = repo.Articles;         
            return View(list);
        }

    }
}
