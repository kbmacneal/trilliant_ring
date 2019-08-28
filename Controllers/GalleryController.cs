using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trill.Classes;
using trill.Models;

namespace trill.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Ads (GalleryModel model)
        {
            List<string> files = System.IO.Directory.GetFiles ("wwwroot/Assets/Ads/").ToList ();

            string prepend = "https://trilliantring.com/Assets/Ads/";

            SortedDictionary<string, string> filenames = new SortedDictionary<string, string> ();

            files.ForEach (e => filenames.Add (System.IO.Path.GetFileName (e), String.Concat (prepend, System.IO.Path.GetFileName (e))));

            List<string> raw_html = new List<string> ();

            KeyValuePair<string, string>[] elements = filenames.ToArray ();

            string add = "<img class=\"photos w-25\" src=\"<element>\" />";

            foreach (KeyValuePair<string, string> element in elements)
            {
                raw_html.Add (add.Replace ("<element>", element.Value));
                filenames.Remove (element.Key);
            }

            model.row_html = String.Join (System.Environment.NewLine, raw_html);

            return View ("Gallery", model);
        }
        public IActionResult Flamingo (GalleryModel model)
        {

            List<string> files = System.IO.Directory.GetFiles ("wwwroot/Assets/FlamingoStuff/").ToList ();

            string prepend = "https://trilliantring.com/Assets/FlamingoStuff/";

            SortedDictionary<string, string> filenames = new SortedDictionary<string, string> ();

            files.ForEach (e => filenames.Add (System.IO.Path.GetFileName (e), String.Concat (prepend, System.IO.Path.GetFileName (e))));

            List<string> raw_html = new List<string> ();

            KeyValuePair<string, string>[] elements = filenames.ToArray ();

            foreach (KeyValuePair<string, string> element in elements)
            {
                string add = "<img class=\"photos w-25\" src=\"<element>\" />";
                raw_html.Add (add.Replace ("<element>", element.Value));
                filenames.Remove (element.Key);
            }

            model.row_html = String.Join (System.Environment.NewLine, raw_html);

            return View ("Gallery", model);
        }

        public IActionResult Icons (GalleryModel model)
        {
            List<string> files = System.IO.Directory.GetFiles ("wwwroot/Assets/Icons/").ToList ();

            string prepend = "https://trilliantring.com/Assets/Icons/";

            SortedDictionary<string, string> filenames = new SortedDictionary<string, string> ();

            files.ForEach (e => filenames.Add (System.IO.Path.GetFileName (e), String.Concat (prepend, System.IO.Path.GetFileName (e))));

            List<string> raw_html = new List<string> ();

            KeyValuePair<string, string>[] elements = filenames.ToArray ();

            foreach (KeyValuePair<string, string> element in elements)
            {
                string add = "<img class=\"photos w-25\" src=\"<element>\" />";
                raw_html.Add (add.Replace ("<element>", element.Value));
                filenames.Remove (element.Key);
            }

            model.row_html = String.Join (System.Environment.NewLine, raw_html);

            return View ("Gallery", model);
        }

        public IActionResult Jaegergems (GalleryModel model)
        {
            List<string> files = System.IO.Directory.GetFiles ("wwwroot/Assets/Jaegergems/").ToList ();

            string prepend = "https://trilliantring.com/Assets/Jaegergems/";

            SortedDictionary<string, string> filenames = new SortedDictionary<string, string> ();

            files.ForEach (e => filenames.Add (System.IO.Path.GetFileName (e), String.Concat (prepend, System.IO.Path.GetFileName (e))));

            List<string> raw_html = new List<string> ();

            KeyValuePair<string, string>[] elements = filenames.ToArray ();

            foreach (KeyValuePair<string, string> element in elements)
            {
                string add = "<img class=\"photos w-25\" src=\"<element>\" />";
                raw_html.Add (add.Replace ("<element>", element.Value));
                filenames.Remove (element.Key);
            }

            model.row_html = String.Join (System.Environment.NewLine, raw_html);

            return View ("Gallery", model);
        }

        public IActionResult Gifs (GalleryModel model)
        {
            List<string> files = System.IO.Directory.GetFiles ("wwwroot/Assets/gifs/").ToList ();

            string prepend = "https://trilliantring.com/Assets/gifs/";

            SortedDictionary<string, string> filenames = new SortedDictionary<string, string> ();

            files.ForEach (e => filenames.Add (System.IO.Path.GetFileName (e), String.Concat (prepend, System.IO.Path.GetFileName (e))));

            List<string> raw_html = new List<string> ();

            KeyValuePair<string, string>[] elements = filenames.ToArray ();

            foreach (KeyValuePair<string, string> element in elements)
            {
                string add = "<img class=\"photos w-25\" src=\"<element>\" />";
                raw_html.Add (add.Replace ("<element>", element.Value));
                filenames.Remove (element.Key);
            }

            model.row_html = String.Join (System.Environment.NewLine, raw_html);

            return View ("Gallery", model);
        }

    }
}