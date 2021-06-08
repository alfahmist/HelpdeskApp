using API.Models;
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
    public class AdminController : Controller
    {
        const string SessionName = "session";
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44397/API/")
        };


        // Index
        [Route("admin")]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString(SessionName);
            if (session != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
            
        }

        [Route("admin/login")]
        public IActionResult Login()
        {
            var session = HttpContext.Session.GetString(SessionName);
            if (session != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Route("admin/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionName);
            return RedirectToAction("Login");
        }

        [Route("ajaxemployee")]
        public async Task<List<dynamic>> Employee()
        {
            List<dynamic> employees = new List<dynamic>();
            var responseTask = client.GetAsync("Employee/All");
       
            var result = responseTask.Result;
            //status code
            if (result.IsSuccessStatusCode)
            {
                var readTask = await result.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<dynamic>>(readTask);
                return employees;
            }

            return employees;
        }
        
        [Route("admin/register")]
        public IActionResult Register()
        {
            return View("register");
        }

        [HttpPost("register/ajaxregister")]
        public HttpStatusCode AjaxRegister(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Accounts/Register", content).Result;
            return result.StatusCode;
        }

       
        [HttpPost("ajaxlogin")]
        public HttpStatusCode AjaxLogin(LoginVM loginVM)
        {
            if(loginVM.Email == "admin@admin.com" && loginVM.Password == "admin")
            {
                HttpContext.Session.SetString(SessionName, "Admin");
                return HttpStatusCode.OK;
            } else
            {
                return HttpStatusCode.Unauthorized;
            }
        }

       
    }
}
