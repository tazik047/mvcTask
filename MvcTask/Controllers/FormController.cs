using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            ViewBag.Sex = form["sex"];
            var additionInf = new List<string>();
            if (form["married"].Contains("true"))
                additionInf.Add("Замужем/Женат");
            if (form["animals"].Contains("true"))
                additionInf.Add("Есть домашние животные");
            if (form["childs"].Contains("true"))
                additionInf.Add("Есть дети");
            ViewBag.Addition = additionInf;
            return View();
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
