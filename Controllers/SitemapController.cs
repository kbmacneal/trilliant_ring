using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;

namespace trill.Controllers {
    public class SitemapController : Controller {
        public ActionResult Index () {
            Assembly asm = Assembly.GetExecutingAssembly ();

            var controlleractionlist = asm.GetTypes ()
                .Where (type => typeof (Controller).IsAssignableFrom (type))
                .SelectMany (type => type.GetMethods (BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where (m => !m.GetCustomAttributes (typeof (System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any ())
                .Select (x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join (",", x.GetCustomAttributes ().Select (a => a.GetType ().Name.Replace ("Attribute", ""))) })
                .OrderBy (x => x.Controller).ThenBy (x => x.Action).ToList ();

            List<SitemapNode> nodes = new List<SitemapNode> ();

            controlleractionlist.ForEach (e => nodes.Add (new SitemapNode (Url.Action (e.Action, e.Controller.Replace ("Controller", "")))));

            return new SitemapProvider ().CreateSitemap (new SitemapModel (nodes));
        }
    }
}