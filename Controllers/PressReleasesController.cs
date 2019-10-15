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
        public async Task<IActionResult> Index () {
            return await Task.Run (() => View ());
        }

        [HttpGet]
        public async Task<IActionResult> Details (string location, Boolean is_PDF = false, Boolean is_HTML = false) {
            PressReleasesModel model = new PressReleasesModel () {
            file_location = location,
            is_PDF = is_PDF,
            is_HTML = is_HTML
            };

            return await Task.Run (() => View (model));
        }
    }
}