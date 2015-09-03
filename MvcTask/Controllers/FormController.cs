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
    public class FormController : Controller
    {
        private IFormRepository repo = new EntityFrameworkFormRepository();

        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Form form)
        {
            return View(form);
        }

        [HttpPost]
        public ActionResult Index(Form form)
        {
            try
            {
                repo.Add(form);
                return RedirectToAction("Save", form);
            }
            catch
            {
                return View(form);
            }
        }
    }
}
