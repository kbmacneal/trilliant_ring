using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace trill.Models {
    public class PressReleasesModel {
        public string raw_html { get; set; }
        public Boolean is_PDF {get;set;} = false;
        public Boolean is_html {get;set;} = true;
        public Boolean is_markdown {get;set;} = false;

    }
}