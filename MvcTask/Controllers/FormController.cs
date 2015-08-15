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

    /*
     * Html.TextBox("name", "", new { placeholder = "Имя" })
        <div class="title">Ваш пол:</div>
        
        @Html.RadioButton("sex", "мужчина", true, new { id = "sex_m" })
        @Html.Label("sex_m", "Мужчина")
        @Html.RadioButton("sex", "женщина", new { id = "sex_w" })
        @Html.Label("sex_w", "Женщина")

        <div class="title">Ваш возраст:</div>
        @Html.DropList(Enumerable.Range(18, 60), name: "age")
        
        <div class="title">Другое:</div>
        @Html.CheckBox("married", new { id="married"})
        @Html.Label("married", )
        @Html.CheckBox("animals", new { id="animals"})
        @Html.Label("animals", "Есть домашние животные")
        @Html.CheckBox("childs", new { id="childs"})
        @Html.Label("childs", "Есть дети")
     * */
}
