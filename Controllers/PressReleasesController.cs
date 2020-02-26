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

        [HttpGet]
        public async Task<IActionResult> DuckInBath () {
            PressReleasesModel model = new PressReleasesModel () {
            file_location = "https://trilliantring.com/PressReleases/turd_in_the_punch_bowl.html",
            is_PDF = false,
            is_HTML = true
            };

            return await Task.Run (() => View ("Details", model));
        }
    }
}