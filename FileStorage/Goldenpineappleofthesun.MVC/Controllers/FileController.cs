using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        // GET: File
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);

                var path = Server.MapPath($"~/Files/{User.Identity.Name}");
                var user = DBHelper.GetUserByLogin(User.Identity.Name);
                var pdoc = DBHelper.GetUserDocument(user, fileName);

                Directory.CreateDirectory(path);

                upload.SaveAs($"{path}/{fileName}");

                if (pdoc == null)
                    DBHelper.AddDocument(fileName, $"{path}/{fileName}", user);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}