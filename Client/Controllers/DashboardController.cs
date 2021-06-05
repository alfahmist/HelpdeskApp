using API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using API.ViewModel;
using Client.ViewModels;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyContext myContext = new MyContext();
        HttpClientHandler clientHandler = new HttpClientHandler();

        OpenedTicketVM ticket = new OpenedTicketVM();
        ClosedTicketVM closedTicket = new ClosedTicketVM();
        InprogressTicketVM inprogress = new InprogressTicketVM();

        List<OpenedTicketVM> tickets = new List<OpenedTicketVM>();
        List<ClosedTicketVM> closedTickets = new List<ClosedTicketVM>();
        List<InprogressTicketVM> progressTicket = new List<InprogressTicketVM>();
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
                return View("Views/Dashboard/OpenedTicket.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult ClosedTicket()
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
                return View("Views/Dashboard/ClosedTicket.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult InProgressTicket()
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
                return View("Views/Dashboard/InprogressTicket.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public async Task<List<ClosedTicketVM>> GetClosedTicket()
        {
            closedTickets = new List<ClosedTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetResponsedTickets"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    closedTickets = JsonConvert.DeserializeObject<List<ClosedTicketVM>>(apiResponse);
                }
            }
            return closedTickets;
        }
        

        [HttpGet]
        public async Task<List<InprogressTicketVM>> AllNewTicketStatus()
        {
            progressTicket = new List<InprogressTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetAllTicketUpdates/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    progressTicket = JsonConvert.DeserializeObject<List<InprogressTicketVM>>(apiResponse);
                }
            }
            return progressTicket;
        }

        [HttpGet]
        public async Task<List<InprogressTicketVM>> GetInprogressTicket()
        {
            progressTicket = new List<InprogressTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetInprogressTickets"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    progressTicket = JsonConvert.DeserializeObject<List<InprogressTicketVM>>(apiResponse);
                }
            }
            return progressTicket;
        }

        [HttpGet]
        public async Task<List<OpenedTicketVM>> GetOpenedTicket()
        {
            tickets = new List<OpenedTicketVM>();
            using (var httpClient = new HttpClient(clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetOpenTickets"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    tickets = JsonConvert.DeserializeObject<List<OpenedTicketVM>>(apiResponse);
                }
            }
            return tickets;
        }
        [HttpPost]
        public HttpStatusCode TicketSolution(TicketResponseVM model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Tickets/ResponseTicket", content).Result;
            return result.StatusCode;
        }
    }
}
