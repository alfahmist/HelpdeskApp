using API.Models;
using API.ViewModel;
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

        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44397/API/")
        };
        // Index
        public IActionResult Index()
        {
            return View();
        }
        public async Task<List<Employee>> Employee()
        {
            List<Employee> employees = new List<Employee>();
            var responseTask = client.GetAsync("Employee");
       
            var result = responseTask.Result;
            // status code
            //if (result.IsSuccessStatusCode)
            //{
                var readTask = await result.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employee>>(readTask);
            //}

            return employees;
        }

        //Register
        public IActionResult Register()
        {
            return View("register");
        }
        [HttpPost("admin/ajaxregister")]
        public HttpStatusCode AjaxRegister(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Accounts/Register", content).Result;
            return result.StatusCode;
        }
        public IActionResult Login()
        {
            return View("login");
        }

    }
}
