using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trill.Models;
using trill.Classes;
using System.IO;

namespace trill.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Memes(GalleryModel model)
        {
            List<string> files = System.IO.Directory.GetFiles("wwwroot/Assets/Memes/").ToList();

            string prepend = "https://highchurch.space/Assets/Memes/";

            SortedDictionary<string,string> filenames = new SortedDictionary<string,string>();

            files.ForEach(e=>filenames.Add(System.IO.Path.GetFileName(e),String.Concat(prepend,System.IO.Path.GetFileName(e))));

            files = System.IO.Directory.GetFiles("wwwroot/Assets/Pinups").ToList();
            prepend = "https://highchurch.space/Assets/Pinups/";

            files.ForEach(e=>filenames.Add(System.IO.Path.GetFileName(e),String.Concat(prepend,System.IO.Path.GetFileName(e))));


            List<string> raw_html = new List<string>();

            while(filenames.Count > 0)
            {                
                raw_html.Add("<div class=\"row row-fluid mb-4\">");

                int count = filenames.Count() >= 3 ? 3 : filenames.Count();

                KeyValuePair<string,string>[] elements = filenames.Take(count).ToArray();

                foreach(KeyValuePair<string,string> element in elements)
                {
                    string add = "<div class=\"col-md-4\"><div class=\"card\"><img class=\"img-scaled\" src=\"<element>\"></div></div>";
                    raw_html.Add(add.Replace("<element>",element.Value));
                    filenames.Remove(element.Key);
                }

                raw_html.Add("</div>");

                // filenames.RemoveRange(0,count);
                
            }

            model.row_html = String.Join(System.Environment.NewLine,raw_html);

            return View("Memes",model);
        }
    }
}