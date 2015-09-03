using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAO.Repository;
using EntityFrameworkDAO.Repository;
using WebMatrix.WebData;

namespace MvcTask.Filters
{
    public class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;
        protected static IUserRepository repo = new EntityFrameworkUserRepository();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Обеспечение однократной инициализации ASP.NET Simple Membership при каждом запуске приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                try
                {
                    repo.Initialize();
                    WebSecurity.InitializeDatabaseConnection("BlogDbContext", "User", "UserId", "UserName", autoCreateTables: true);
                    var roles = (SimpleRoleProvider)Roles.Provider;
                    var membership = (SimpleMembershipProvider)Membership.Provider;
                    var startRoles = new[] { "Admin", "User" };
                    foreach (var role in startRoles)
                    {
                        if (!roles.RoleExists(role))
                        {
                            roles.CreateRole(role);
                        }
                    }

                    if (membership.GetUser("admin", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("admin", "nimda",
                        new { FirstName = "Admin", LastName = "Admin", Email = "admin@blod.com" });

                        roles.AddUsersToRoles(new[] { "admin" }, new[] { startRoles[0] });
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Не удалось инициализировать базу данных ASP.NET Simple Membership. Чтобы получить дополнительные сведения, перейдите по адресу: http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}