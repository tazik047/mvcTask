using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repository;
using EntityFrameworkDAO.Repository;
using DAO.Model;

namespace MvcTask.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        //
        // GET: /admin/Tag/
        ITagRepository repo = new EntityFrameworkTagRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        //
        // GET: /admin/Tag/Details/5

        public ActionResult Details(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // GET: /admin/Tag/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /admin/Tag/Create

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Add(tag);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View(tag);
        }

        //
        // GET: /admin/Tag/Edit/5

        public ActionResult Edit(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // POST: /admin/Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Edit(tag);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                
            }
            return View(tag);
        }

        //
        // GET: /admin/Tag/Delete/5

        public ActionResult Delete(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // POST: /admin/Tag/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Delete(id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View();
        }
    }
}
