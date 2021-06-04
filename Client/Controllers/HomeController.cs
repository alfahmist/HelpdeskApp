using API.Context;
using API.Models;
using API.ViewModel;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string SessionName = "_Name";
        const string SessionToken = "_Token";
        private readonly MyContext myContext = new MyContext();
        public HomeController(MyContext myContext, ILogger<HomeController> logger)
        {
            this.myContext = myContext;
            _logger = logger;
        }
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44397/API/")
        };


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
                return View("Views/Home/Index.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            //ViewBag.Name = HttpContext.Session.GetString(SessionName);
            //ViewBag.name = "Hello";
            //if(ViewBag.Name == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Index", "Login");
        }
        
        public JsonResult GetTicketID(int id)
        {
           
            var responseTask = client.GetAsync($"Tickets/{id}");
            //responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                var tickets = readTask.Result;
                return Json(tickets);
            }
            return Json(null);
        }

        [HttpPost]
        public HttpStatusCode CreateTicket(CreateTicketVM model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Tickets/CreateTicket", content).Result;
            return result.StatusCode;
        }
        
        [HttpPost]
        public HttpStatusCode TicketSolution(TicketResponseVM model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Tickets/ResponseTicket", content).Result;
            return result.StatusCode;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
