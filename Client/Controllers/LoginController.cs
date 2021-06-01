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
        public IActionResult Index()
        {
            //HttpContext.Session.SetString("text","session value");
            return View("Views/Login/index.cshtml");
        }
    }
}
