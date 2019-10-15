using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trill.Classes;
using trill.Models;

namespace trill.Controllers {
    public class PressReleasesController : Controller {
        [HttpGet]
        public IActionResult Index () {
            return View ();
        }

        [HttpGet]
        public IActionResult GetHTML () {
            return View ();
        }

        [HttpGet]
        public IActionResult GetPDF () {
            return View ();
        }

        [HttpGet]
        public IActionResult GetMarkDown () {
            return View ();
        }
    }
}