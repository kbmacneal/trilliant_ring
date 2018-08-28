using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trill.Models;

namespace trill.Controllers
{
    public class ContentController : Controller
    {
        [HttpGet]
        public ActionResult Support () {

            return View ();
        }
    }
}
