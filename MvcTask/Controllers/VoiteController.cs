using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repository;
using DAO.Model;

namespace MvcTask.Controllers
{
    public class VoiteController : Controller
    {
        IVoiteRepository repo = new EntityFrameworkDAO.Repository.EntityFrameworkVoiteRepository();

        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Summary()
        {
            ViewBag.Summary = repo.Summary();
            return PartialView();
        }

        //
        // GET: /Voite/

        public ActionResult Voite(Voite v)
        {
            //var v = new Voite{Ip = HttpContext.Request.UserHostAddress, Mark = mark};
            repo.Add(v);
            return RedirectToAction("Index", "Home");
        }

    }
}
