using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTask.Helper
{
    public static class RenderHelper
    {
        public static MvcBlock BeginRightBlock(this HtmlHelper helper, string title)
        {
            return new MvcBlock(helper.ViewContext, title);
        }
    }
}