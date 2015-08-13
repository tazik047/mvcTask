using MvcTask.Models;
using MvcTask.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Controllers
{
    public class GuestController : Controller
    {
        private Repositoriy repo = new Repositoriy();

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            var list = repo.LastReviews(5);
            ViewBag.Reviews = list;
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Review review)
        {
            try
            {
                ViewBag.Name = review.Name;
                repo.Add(review);
                return View();
            }
            catch (Exception)
            {
                return View("Index", review);
            }
        }

    }
}
