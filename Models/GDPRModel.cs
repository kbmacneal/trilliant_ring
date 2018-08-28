using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace trill.Models
{
    public class GDPRModel
    {
        public string EmailData{get;set;}
        public string IPData {get;set;}
        public Boolean CheckboxData {get;set;}
        
    }
}