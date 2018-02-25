using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class SamplesController : Controller
    {
        private string JsonSamples = "{}";
        /*private IEnumerable<SampleItem> samples = new List<SampleItem>();*/

        // GET: Samples
        [HttpPost]
        public string GetAll()
        {
            // TODO: можно ли заменить джейсон на что нибудь другое?
            if (JsonSamples != "{}")
                return JsonSamples;

            JsonSamples = "";

            var samples = DBHelper.GetAllSamples();

            for (var i=0; i<samples.Count(); i++)
            {
                var item = samples.ElementAt(i);
                JsonSamples += $"\"{item.Id}\": {{\"id\":\"{item.Id}\", \"title\":\"{item.Title}\"}}{(i < samples.Count()-1 ? ',' : ' ')}";
            }

            JsonSamples = $"{{{JsonSamples}}}";

            return JsonSamples;
        }

        [HttpPost]
        public void Create(long selected, string name)
        {
            var sample = DBHelper.GetSample(selected);

            // аплоад
            if (sample != null)
            {
                var user = DBHelper.GetUserByLogin(User.Identity.Name);
                var samplepath = Server.MapPath($"~\\Samples\\{System.IO.Path.GetFileName(sample.RelPath)}");
                var ext = Path.GetExtension(sample.RelPath);
                var path = Server.MapPath($"~\\Files\\{User.Identity.Name}");

                name = name + ext;
                
                Directory.CreateDirectory(path);

                System.IO.File.Copy(samplepath, $"{path}\\{name}", true);

                var pdoc = DBHelper.GetUserDocument(user, name);

                if (pdoc == null)
                    DBHelper.AddDocument(name, $"{path}\\{name}", user);
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);

                var path = Server.MapPath($"~\\Samples\\");
                var pdoc = DBHelper.GetSampleByPath(path);

                upload.SaveAs($"{path}/{fileName}");

                if (pdoc == null)
                    DBHelper.AddSample(fileName, fileName);
            }

            return RedirectToAction("Samples", "Manage");
        }
        
        [HttpPost]
        public ActionResult Delete(long id, string path)
        {
            // TODO: Status inst of actual removing 
            var smpl = DBHelper.GetSample(id);

            if (smpl != null)
            {
                System.IO.File.Delete(Server.MapPath($"~\\Samples\\{smpl.RelPath}"));
                DBHelper.DeleteSample(smpl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Rename(long id, string name)
        {
            var smpl = DBHelper.GetSample(id);

            if (smpl != null)
            {
                DBHelper.RenameSample(smpl, name);
            }

            return RedirectToAction("Samples", "Manage");
        }
    }
}