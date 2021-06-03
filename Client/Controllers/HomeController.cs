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
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44397/API/")
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.name = "Hello";
            if(ViewBag.Name == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
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
