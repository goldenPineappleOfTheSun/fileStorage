using Goldenpineappleofthesun.Database.Models;
using Goldenpineappleofthesun.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = DBHelper.GetUserByLogin(User.Identity.Name);

            // предварительная сортровка
            // основная сортировка находится во фронтенде 
            var files = DBHelper.GetAllUserDocuments(user)
                .OrderBy(x => x.Name);

            // todo: perfotmance
            foreach (DocumentItem file in files)
            {
                if (file.Status == DocumentStatus.Missed)
                    if (System.IO.File.Exists(file.FileName))
                    {
                        file.Status = DocumentStatus.Normal;
                        DBHelper.MarkDocumentAsNormal(file);
                    }
            }

            return View(files);
        }
        
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Title = "Файловый менеджер.";
            ViewBag.Message = "Динное и наполненное смыслом описание файлового менеджера.";

            return View();
        }
    }
}