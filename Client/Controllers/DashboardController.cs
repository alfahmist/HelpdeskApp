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
        public int ticketNumber { get; set; }
        public int TicketAllCount { get; set; }
        public DashboardController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44397/API/")
        };
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
            ticketNumber = progressTicket.Count;

            return progressTicket;
        }

        [Route("Dashboard/TicketDetail/{id?}")]
        public IActionResult TicketDetail(string id)
        {
            //var token = HttpContext.Session.GetString("JWToken");
            //if (token != null)
            //{
            //    var jwtReader = new JwtSecurityTokenHandler();
            //    var jwt = jwtReader.ReadJwtToken(token);

            //    var email = jwt.Claims.First(e => e.Type == "email").Value;
            //    var emailDb = myContext.Employees.FirstOrDefault(emp => emp.Email == email);
            //    var empId = emailDb.Id;
            //    if (id == "")
            //    {
            //        return RedirectToAction("Index", "Dashboard");
            //    }

                //ViewData["ticketID"] = id;
                //ViewData["empId"] = empId;
                //var tCount = GetTicketMessage(id);
                return View("TicketDetail");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}

        }
        [HttpPost]
        public HttpStatusCode NewTicketMessage(SendMessageVM model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Tickets/NewTicketMessage", content).Result;
            return result.StatusCode;
        }

        public JsonResult TicketDetailById(string ticketId)
        {

            //var id = Request.Query["ticketId"];
            var responseTask = client.GetAsync($"Tickets/TicketDetailById/{ticketId}");
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
        [Route("Dashboard/Account")]
        public IActionResult Account()
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
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public async Task<IList<TicketMessageVM>> GetTicketMessage(string id)
        {

            var responseTask = client.GetAsync($"Tickets/GetTicketMessage/{id}");
            //responseTask.Wait();
            var result = responseTask.Result;

            string apiResponse = await result.Content.ReadAsStringAsync();
            var ticketMessage = JsonConvert.DeserializeObject<List<TicketMessageVM>>(apiResponse);
            ViewData["tCount"] = ticketMessage.Count();
            return ticketMessage;

        }
        public IActionResult Index()
        {
            //ViewData["ticketNumber"] = ticketNumber;
            //var token = HttpContext.Session.GetString("JWToken");
            //if (token != null)
            //{
            //    var jwtReader = new JwtSecurityTokenHandler();
            //    var jwt = jwtReader.ReadJwtToken(token);

            //    var name = jwt.Claims.First(c => c.Type == "unique_name").Value;
            //    var email = jwt.Claims.First(e => e.Type == "email").Value;
            //    var emailDb = myContext.Employees.FirstOrDefault(emp => emp.Email == email);
            //    var empId = emailDb.Id;
            //    var role = jwt.Claims.First(c => c.Type == "role").Value;
            //    ViewData["name"] = name;
            //    ViewData["empId"] = empId;
            //    ViewData["TicketAllCount"] = TicketAllCount;
            //    if (role.ToString().ToLower() == "client")
            //    {
            //        //ForClient
                //    return RedirectToAction("Index", "Login");
                //}
                //else
                //{
                //    //For non-Client
                    return View("Views/Dashboard/Index.cshtml");
            //    }
             
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            
        }

        public IActionResult Login()
        {
            //ViewData["ticketNumber"] = ticketNumber;
            //var token = HttpContext.Session.GetString("JWToken");
            //if (token != null)
            //{
            //    var jwtReader = new JwtSecurityTokenHandler();
            //    var jwt = jwtReader.ReadJwtToken(token);

            //    var name = jwt.Claims.First(c => c.Type == "unique_name").Value;
            //    var email = jwt.Claims.First(e => e.Type == "email").Value;
            //    var emailDb = myContext.Employees.FirstOrDefault(emp => emp.Email == email);
            //    var empId = emailDb.Id;
            //    var role = jwt.Claims.First(c => c.Type == "role").Value;
            //    ViewData["name"] = name;
            //    ViewData["empId"] = empId;
            //    ViewData["TicketAllCount"] = TicketAllCount;
            //    if (role.ToString().ToLower() == "client")
            //    {
            //        //ForClient
            //    return RedirectToAction("Index", "Login");
            //}
            //else
            //{
            //    //For non-Client
            return View("Login");
            //    }

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}

        }


        public IActionResult Technical()
        {
            //ViewData["ticketNumber"] = ticketNumber;
            //var token = HttpContext.Session.GetString("JWToken");
            //if (token != null)
            //{
            //    var jwtReader = new JwtSecurityTokenHandler();
            //    var jwt = jwtReader.ReadJwtToken(token);

            //    var name = jwt.Claims.First(c => c.Type == "unique_name").Value;
            //    var email = jwt.Claims.First(e => e.Type == "email").Value;
            //    var emailDb = myContext.Employees.FirstOrDefault(emp => emp.Email == email);
            //    var empId = emailDb.Id;
            //    var role = jwt.Claims.First(c => c.Type == "role").Value;
            //    ViewData["name"] = name;
            //    ViewData["empId"] = empId;
            //    ViewData["TicketAllCount"] = TicketAllCount;
            //    if (role.ToString().ToLower() == "client")
            //    {
            //        //ForClient
            //    return RedirectToAction("Index", "Login");
            //}
            //else
            //{
            //    //For non-Client
            return View("Technical");
            //    }

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}

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
        
        //[HttpGet]
        //public async Task<List<InprogressTicketVM>> AllNewTicketStatus()
        //{
        //    progressTicket = new List<InprogressTicketVM>();
        //    using (var httpClient = new HttpClient(clientHandler))
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44397/api/Tickets/GetAllTicketUpdates/"))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            progressTicket = JsonConvert.DeserializeObject<List<InprogressTicketVM>>(apiResponse);
                  
            
        //        }
        //    }  
        //    TicketAllCount = progressTicket.Count;
          
        //    return progressTicket;
        //}

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
