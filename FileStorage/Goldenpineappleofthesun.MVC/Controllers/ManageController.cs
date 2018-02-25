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
        public ActionResult Samples()
        {
            var samples = DBHelper.GetAllSamples();
            return View(samples);
        }
    }
}