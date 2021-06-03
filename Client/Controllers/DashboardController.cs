using API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        private MyContext myContext = new MyContext();
        public DashboardController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            
            var token = HttpContext.Session.GetString("JWToken");
            if (token != null)
            {
                var jwtReader = new JwtSecurityTokenHandler();
                var jwt = jwtReader.ReadJwtToken(token);

                var name = jwt.Claims.First(c => c.Type == "unique_name").Value;
                var email = jwt.Claims.First(e => e.Type == "email").Value;
                var emailDb = myContext.Employees.FirstOrDefault(emp => emp.Email == email);
                var empId = emailDb.Id;

                ViewData["name"] = name;
                ViewData["empId"] = empId;
                return View("Views/Dashboard/Index.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public IActionResult OpenedTicket()
        {
            return View();
        }

        public IActionResult ClosedTicket()
        {
            return View();
        }
        public IActionResult InProgressTicket()
        {
            return View();
        }
    }
}
