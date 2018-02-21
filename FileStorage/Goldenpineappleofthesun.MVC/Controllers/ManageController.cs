using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            var users = DBHelper.GetAllUsers()
                .Where(u => u.Status != UserStatus.Deleted);
            return View(users);
        }
    }
}