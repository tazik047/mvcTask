using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Model;
using DAO.Repository;
using EntityFrameworkDAO.Repository;

namespace MvcTask.Controllers
{
    public class GuestController : Controller
    {
        private IReviewRepository repo = new EntityFrameworkReviewRepository();

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            ViewBag.Reviews = repo.GetFirtNItem(5);
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
