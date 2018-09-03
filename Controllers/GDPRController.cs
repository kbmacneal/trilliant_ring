using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using trill.Classes;
using trill.Models;

namespace emperor_mvc.Controllers {

    public class GDPRController : Controller {
        public IActionResult Index () {
            return View ();
        }

        [HttpPost]
        public ActionResult Index (string EmailData, string IPData, Boolean CheckboxData) {

            if (ModelState.IsValid) {
                response response = new response ();
                response.EmailData = EmailData;
                response.IPData = IPData;
                response.CheckboxData = CheckboxData;

                GDPR.RegisterResponse (response);
            }
            return View ("Success");
        }

        [HttpGet]
        public ActionResult Success () {
            return View ();
        }
    }
}