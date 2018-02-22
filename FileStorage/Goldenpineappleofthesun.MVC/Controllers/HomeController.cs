using Goldenpineappleofthesun.Database.Models;
using Goldenpineappleofthesun.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = DBHelper.GetUserByLogin(User.Identity.Name);
            var files = DBHelper.GetAllUserDocuments(user);
            return View(files);
        }
    }
}