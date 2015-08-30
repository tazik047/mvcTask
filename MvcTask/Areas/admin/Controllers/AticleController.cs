using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAO.Repository;
using EntityFrameworkDAO.Repository;
//using DAO.Model;
using MvcTask.Models;
using MvcTask.Areas.admin.Models;

namespace MvcTask.Areas.admin.Controllers
{
    public class AticleController : Controller
    {
        //
        // GET: /admin/Aticle/
        IArticleRepositry repo = new EntityFrameworkArticleRepository();
        ITagRepository repoTag = new EntityFrameworkTagRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll().Select(a => new PreviewArticle(a)));
        }

        //
        // GET: /admin/Aticle/Details/5

        public ActionResult Details(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // GET: /admin/Aticle/Create

        public ActionResult Create()
        {
            ViewBag.Tags = repoTag.GetAll().Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString() });
            return View();
        }

        //
        // POST: /admin/Aticle/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            try
            {
                
                /*if (ModelState.IsValid)
                {*/
                    repo.Add(article.OriginArticle);
                    return RedirectToAction("Index");
                /*}
                else
                {
                    int a = 1;
                }*/
                
            }
            catch
            {
                
            }
            return View(article);
        }

        //
        // GET: /admin/Aticle/Edit/5

        public ActionResult Edit(int id)
        {
            var tags = repoTag.GetAll();
            repoTag.Close();
            return View(new Article(repo.FindById(id), tags));
        }

        //
        // POST: /admin/Aticle/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Edit(article.OriginArticle);
                    return RedirectToAction("Index");
                }
                else
                {
                    int a = 1;
                }
                
            }
            catch
            {
                
            }
            return View(article);
        }

        //
        // GET: /admin/Aticle/Delete/5

        public ActionResult Delete(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // POST: /admin/Aticle/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
