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
        public async Task<IActionResult> AcceptingPerfection () {
            PressReleasesModel model = new PressReleasesModel () {
            file_location = "https://trilliantring.com/PressReleases/AcceptingPerfection.html",
            is_PDF = false,
            is_HTML = true
            };

            return await Task.Run (() => View ("Details", model));
        }
    }
}