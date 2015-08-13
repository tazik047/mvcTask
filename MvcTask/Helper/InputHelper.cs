using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Helper
{
    public static class InputHelper
    {
        public static MvcHtmlString DropList<T>(this HtmlHelper helper, IEnumerable<T> items, string className = "", string name = "")
        {
            return list("select", "option", items, className, name);
        }

        private static MvcHtmlString list<T>(string nameTag, string subTag, IEnumerable<T> items, string className = "", string name = "")
        {
            TagBuilder tag = new TagBuilder(nameTag);
            tag.AddCssClass(className);
            tag.MergeAttribute("name", name);
            foreach (T i in items)
            {
                TagBuilder op = new TagBuilder(subTag);
                op.MergeAttribute("value", i.ToString());
                op.InnerHtml +=i.ToString();
                tag.InnerHtml += op.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString UlList<T>(this HtmlHelper helper, IEnumerable<T> items, string className = "", string name = "")
        {
            return list("ul", "li", items, className, name);
        }
    }
}