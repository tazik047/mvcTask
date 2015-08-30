using MvcTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAO.Repository;
using EntityFrameworkDAO.Repository;
using DAO.Model;
using MvcTask.SetupMapper;

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
            ArticleMapper.MapForPreview(200);
            return View(list.Select(Mapper.Map<Article, PreviewArticle>));
        }

        public ActionResult Article(long id)
        {
            return View(repo.FindById(id));
        }

    }
}
