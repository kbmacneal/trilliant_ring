using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace trill.Models {
    public class apiModel {
        public List<Controllers.leaderboard> leaderboard{get;set;}

        public string api_key {get;set;}
    }
}