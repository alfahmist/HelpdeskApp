using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
