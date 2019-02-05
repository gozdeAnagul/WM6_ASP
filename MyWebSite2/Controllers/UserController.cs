using MyWebSite2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserVM item)
        {
            return View();
        }
    }
}