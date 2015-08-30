using System.Web.Mvc;

namespace MvcTask.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "Main" },
                namespaces: new[] { "MvcTask.Areas.admin.Controllers" }
            );
        }
    }
}
