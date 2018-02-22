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

            // TODO: управляемая сортировка
            // этим контроллером всегда пользуется один авторизированный пользователь,
            // поэтому я не стал сортировать по автору
            var files = DBHelper.GetAllUserDocuments(user)
                .OrderBy(x => x.Name)
                .OrderBy(x => x.CreationDate);

            return View(files);
        }
    }
}