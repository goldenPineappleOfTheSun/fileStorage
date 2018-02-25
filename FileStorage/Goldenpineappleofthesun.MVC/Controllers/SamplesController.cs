﻿using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize]
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

                /*  var path = Server.MapPath($"~\\Files\\{User.Identity.Name}");
                  var user = DBHelper.GetUserByLogin(User.Identity.Name);
                  var pdoc = DBHelper.GetUserDocument(user, fileName);

                  Directory.CreateDirectory(path);

                  upload.SaveAs($"{path}/{fileName}");

                  if (pdoc == null)
                      DBHelper.AddDocument(fileName, $"{path}\\{fileName}", user);*/
            }

            //return RedirectToAction("Index", "Home");
        }
     }
}