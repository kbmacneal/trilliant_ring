using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using trill.Classes;
using trill.Models;
using Microsoft.AspNetCore.Mvc;
using Westwind.Utilities;

namespace trill.Controllers {
    public class LeaderboardController : Controller {

        [HttpGet]
        public ActionResult Index () {

            ViewBag.leaderboard_stats = Controllers.stats.get_stats().leaderboard;
            return View ();
        }
    }
}
