using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MainController : Controller
    {
        //
        // GET: /admin/Main/

        public ActionResult Index()
        {
            return View();
        }

    }
}
