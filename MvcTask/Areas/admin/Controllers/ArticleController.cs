using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAO.Repository;
using EntityFrameworkDAO.Repository;
//using DAO.Model;
using MvcTask.Models;
using MvcTask.Areas.admin.Models;
using MvcTask.SetupMapper;

namespace MvcTask.Areas.admin.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /admin/Article/
        IArticleRepositry repo = new EntityFrameworkArticleRepository();
        ITagRepository repoTag = new EntityFrameworkTagRepository();

        public ActionResult Index()
        {
            ArticleMapper.MapForPreview(200);
            return View(repo.GetAll().Select(Mapper.Map<DAO.Model.Article, PreviewArticle>));
        }

        //
        // GET: /admin/Article/Details/5

        public ActionResult Details(int id = 0)
        {
            var article = repo.FindById(id);
            if (article == null)
                return HttpNotFound();
            return View(article);
        }

        //
        // GET: /admin/Article/Create

        public ActionResult Create()
        {
            TempData["Tags"] = repoTag.GetAll().Select(t => new SelectListItem { Text = t.Title, Value = t.TagId.ToString() });
            TempData.Keep("Tags");
            return View();
        }

        //
        // POST: /admin/Article/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var origin = article.OriginArticle;
                    var selectedTags = repoTag.Find(t => article.Tags.Any(id => id == t.TagId));
                    origin.Tags = selectedTags;
                    repo.Add(origin);
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            TempData.Keep("Tags");
            return View(article);
        }

        //
        // GET: /admin/Article/Edit/5

        public ActionResult Edit(int id)
        {
            TempData["AllTags"] = repoTag.GetAll();
            TempData.Keep("AllTags");
            ArticleMapper.MapForEditing();
            return View(Mapper.Map<DAO.Model.Article, Article>(repo.FindById(id)));
        }

        //
        // POST: /admin/Article/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var origin = article.OriginArticle;
                    var selectedTags = repoTag.Find(t => article.Tags.Any(id => id == t.TagId));
                    origin.Tags = selectedTags;
                    repo.Edit(origin);
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            TempData.Keep("AllTags");
            return View(article);
        }

        //
        // GET: /admin/Article/Delete/5

        public ActionResult Delete(int id)
        {
            return View(repo.FindById(id));
        }

        //
        // POST: /admin/Article/Delete/5

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
