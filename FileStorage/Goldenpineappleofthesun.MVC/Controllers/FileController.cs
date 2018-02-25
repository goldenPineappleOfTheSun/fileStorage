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

                var path = Server.MapPath($"~\\Files\\{User.Identity.Name}");
                var user = DBHelper.GetUserByLogin(User.Identity.Name);
                var pdoc = DBHelper.GetUserDocument(user, fileName);

                Directory.CreateDirectory(path);

                upload.SaveAs($"{path}/{fileName}");

                if (pdoc == null)
                    DBHelper.AddDocument(fileName, $"{path}\\{fileName}", user);
            }

            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public ActionResult Delete(string login, string name)
        {
            var doc = DBHelper.GetUserDocument(login, name);

            if (doc != null)
            {
                System.IO.File.Delete(doc.FileName);
                DBHelper.DeleteDocument(doc);
            }

            return View();
        }

        // GET: File
        [HttpPost]
        public ActionResult Open(string path, long id)
        {
            if (!System.IO.File.Exists(path))
            {
                var file = DBHelper.GetDocument(id);
                DBHelper.MarkDocumentAsMissed(file);
                return View();
            }

            System.Diagnostics.Process.Start(path);

            return View();
        }
    }
}