using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using trill.Classes;
using trill.Models;
using Microsoft.AspNetCore.Mvc;

namespace trill.Controllers {
    public class LeaderboardController : Controller {

        [HttpGet]
        public ActionResult Index (apiModel model) {
            model.leaderboard = Controllers.stats.get_stats().leaderboard.Replace(System.Environment.NewLine, "<br />");
            return View (model);
        }
    }
}
