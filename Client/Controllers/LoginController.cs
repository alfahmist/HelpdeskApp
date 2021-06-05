using API.Context;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        const string SessionName = "_Name";

        const string SessionToken = "_Token";
        private MyContext myContext = new MyContext();

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Login()
        {
            HttpContext.Session.GetString("JWToken");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ResetPassword()
        {
            if (Request.Query.ContainsKey("token"))
            {
                var token = Request.Query["token"].ToString();
                ViewData["token"] = token;
                return View();
            }
            return NotFound();
        }

        public string LoginEmployee(LoginVM login)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44397/api/Accounts/Login", stringContent).Result;
            var token = result.Content.ReadAsStringAsync().Result;

            HttpContext.Session.SetString("JWToken", token);

            if (result.IsSuccessStatusCode)
            {
                var jwtReader = new JwtSecurityTokenHandler();
                var jwt = jwtReader.ReadJwtToken(token);

                var role = jwt.Claims.First(c => c.Type == "role").Value;
               

                if (role.ToString().ToLower() == "client") 
                {
                    //ForClient
                    return Url.Action("Index", "Home");
                }
                else
                {
                    //For non-Client
                    return Url.Action("Index", "Dashboard");
                }
            }
            else
            {
                return "Error";
                //return BadRequest(new { result });
            }
        }
        [HttpPost]
        public HttpStatusCode Register(RegisterVM registerVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Accounts/Register", content).Result;
            return result.StatusCode;
        }
        
        //[HttpPost]
        //public HttpStatusCode AuthLogin(LoginVM loginVM)
        //{
        //    var httpclient = new HttpClient();
            
        //    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
        //    var result = httpclient.PostAsync("https://localhost:44397/api/Accounts/Login", stringContent).Result;

           
        //    if((int)result.StatusCode == 200)
        //    {
        //        var responseBody = result.Content.ReadAsStringAsync().Result;
        //        //HttpContext.Session.SetString("token", responseBody.Result.ToString());
        //        httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + responseBody);
        //        HttpContext.Session.SetString(SessionName, loginVM.Email);
       
        //        HttpContext.Session.SetString(SessionToken, responseBody);
        //    }
        //    return result.StatusCode;
        //}

        public IActionResult ResetPasswords(ResetVM model)
        {
            var client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44397/api/Accounts/reset-password/", stringContent).Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(new { result });
            }
            else
            {
                return BadRequest(new { result });
            }
        }

        public IActionResult ForgotPassword(ForgotVM forgotVM)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(forgotVM), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://localhost:44397/api/Accounts/ForgotPassword", content).Result;
            if (result.IsSuccessStatusCode)
            {
                return Ok(new { result });
            }
            else
            {
                return BadRequest(new { result });
            }
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
