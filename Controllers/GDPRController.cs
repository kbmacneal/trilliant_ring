using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using trill.Classes;
using trill.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using JsonFlatFileDataStore;
using Microsoft.Extensions.Primitives;

namespace trill.Controllers
{
    public class CookieRegister
    {
        public string time { get; set; }
        public string address { get; set; }

        public async void insert_cookie_register()
        {
            // Open database (create new if file doesn't exist)
            var store = new DataStore("data.json");

            // Get employee collection
            var collection = store.GetCollection<CookieRegister>();

            await collection.InsertOneAsync(this);

            store.Dispose();
        }
    }

    [Produces("application/json")]
    public class GDPRController : Controller
    {
        private IHttpContextAccessor _accessor;

        public GDPRController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CookieRegister([FromBody] GDPRModel data)
        {
            DateTime now = DateTime.Now.ToUniversalTime();
            string IPData = data.IPData.Trim();

            CookieRegister reg = new CookieRegister
            {
                time = now.ToString(),
                address = IPData
            };

            reg.insert_cookie_register();

            return Ok();
        }

        [HttpPost]
        public ActionResult Index(string EmailData, string IPData, Boolean CheckboxData, string label_text)
        {

            if (ModelState.IsValid)
            {

                if (IPData == null)
                {
                    // IPData = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    IPData = label_text;
                }

                response response = new response();
                response.EmailData = EmailData;
                response.IPData = IPData;
                response.CheckboxData = CheckboxData;

                if (!validate_request(EmailData, IPData, CheckboxData))
                {
                    return View("Problem");
                }
                else
                {
                    GDPR.RegisterResponse(response);
                    return View("Success");
                }
            }
            else
            {
                return View("Problem");
            }

        }

        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }

        private bool validate_request(string email, string ip, Boolean CheckboxData)
        {
            int rtner = 0;
            System.Net.IPAddress addr = System.Net.IPAddress.Parse("1.1.1.1");

            if (email != null)
            {
                if (email.Contains("@")) rtner++;
            }

            if (System.Net.IPAddress.TryParse(ip, out addr)) rtner++;

            if (CheckboxData) rtner++;

            if (rtner == 3)
            {
                return true;
            }
            else
            { return false; }
        }
    }
}