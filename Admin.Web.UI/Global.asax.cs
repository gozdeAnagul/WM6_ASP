using Admin.BLL.Identity;
using Admin.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Admin.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var roller = new string[] { "Admin", "User" };
            var roleMenager = MembershipTools.NewRoleMenager();
            foreach (var rol in roller)
            {
                if (!roleMenager.RoleExists(rol))
                {
                    roleMenager.Create(new Role
                    {
                        Name =rol
                    });
                }
            }
        }

         
    }
}
