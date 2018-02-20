using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*var doc = new DocumentItem();
            var user = new UserItem();
            user.Id = 0;
            doc.Name = "Dasha";
            doc.Author = user;
            doc.CreationDate = DateTime.Now;
            doc.FileName = "path";*/

            DBHelper.AddUser("dasha", "123", "Даша", "Standart");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}