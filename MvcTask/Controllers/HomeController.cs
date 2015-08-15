using MvcTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repository;
using EntityFrameworkDAO.Repository;

namespace MvcTask.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepositry repo = new EntityFrameworkArticleRepository();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = repo.GetAll();         
            return View(list);
        }

    }
}
