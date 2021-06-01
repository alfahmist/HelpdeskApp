using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";

        public IActionResult Index()
        {
          
            return View("Views/Login/index.cshtml");
        }

        public IActionResult Login(string loginEmail)
        {
            HttpContext.Session.SetString(SessionName, loginEmail);
            HttpContext.Session.SetInt32(SessionAge, 24);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public HttpStatusCode Login(LoginVM loginVM)
        {
            var httpclient = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = httpclient.PostAsync("https://localhost:44387/api/Account/Login/", stringContent).Result;
            return result.StatusCode;
        }
    }
}
