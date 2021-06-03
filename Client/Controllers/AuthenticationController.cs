using API.Context;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AuthenticationController : Controller
    {
        private MyContext myContext = new MyContext();
        const string SessionToken = "_Token";
        public IActionResult Index()
        {
            return View("Views/Authentication/Index.cshtml");
        }

        [HttpPost]
        public HttpStatusCode Login(LoginVM loginVM)
        {
            var httpclient = new HttpClient();

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            var result = httpclient.PostAsync("https://localhost:44397/api/Accounts/Login", stringContent).Result;

            if ((int)result.StatusCode == 200)
            {
                var responseBody = result.Content.ReadAsStringAsync().Result;  
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBody);
                HttpContext.Session.SetString(SessionToken, responseBody);
            }
            return result.StatusCode;
        }

        [HttpPost]
        public HttpStatusCode Register(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Accounts/Register", content).Result;
            return result.StatusCode;
        }
        [HttpPut]
        public HttpStatusCode ForgotPassword(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44397/api/Accounts/reset/", content).Result;
            return result.StatusCode;
        }
        [HttpPut]
        public HttpStatusCode ChangePassword(ChangePasswordVM changePasswordViewModels)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordViewModels), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync("https://localhost:44397/api/Accounts/ChangePassword/", content).Result;
            return result.StatusCode;
        }
    }
}