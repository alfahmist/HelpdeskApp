//Hashing
using API.Base;
using API.Context;
using API.Handler;
using API.Middleware;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
//For JWT Services
using API.Services;
using API.ViewModel;
//For Store Procedure
using Dapper;
//For ALlow Annonymous
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
//DBType
using System.Data;
//For JWT Security Token Handler
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<AccountClient, AccountRepository, int>
    {
        private readonly IGenericDapper dapper;
        private readonly MyContext myContext;
        private IConfiguration Configuration;
        private AccountRepository accountRepository;

        public AccountsController(AccountRepository accountRepository,
            IConfiguration Configuration,
            IGenericDapper dapper,
            MyContext myContext) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.Configuration = Configuration;
            this.dapper = dapper;
            this.myContext = myContext;
        }

        [HttpPost("forgot-password")]
        public ActionResult ForgotPassword(string email)
        {

            string sender = "aninsabrina17@gmail.com";
            string pwd = "yulisulasta";
            string url = "https://localhost:44327/";
            //sender
            var user = new SmtpClient("smtp.gmail.com", 587) //bikin 1 handler sendiri
            {
                UseDefaultCredentials = true,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(sender, pwd ),
            };
            
            var jwt = new JwtService(Configuration);
            string token = jwt.ForgotToken(email);
            MailHandler mailHandler = new MailHandler(sender, email, url, token);


            user.Send(mailHandler.Message());
            return Ok();
         
        }

        [HttpPost("reset-password/{token}")]
        public ActionResult ResetPassword(string newPassword, string token)
        {
            var jwt = new JwtSecurityTokenHandler();
            // read jwt baca isi token
            try
            {
                var jwtRead = jwt.ReadJwtToken(token);
                // new password
                var email = jwtRead.Claims.First(claim => claim.Type == "email").Value;
                var client = myContext.Clients.FirstOrDefault(x => x.Email == email);
                if(client == null)
                {
                    return NotFound();
                }

                var account = client.AccountClient;
                // Bcrypt
                account.Password = Hashing.HashPassword(newPassword);
                // Update
                var result = accountRepository.Put(account) > 0 ? (ActionResult)Ok("Password has been updated") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (ArgumentException)
            {
                return Unauthorized(new { Status = "Failed", Message = "Link is expired" });
            }
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var password = Hashing.HashPassword(registerVM.Password);
            var dbparams = new DynamicParameters();

            dbparams.Add("Name", registerVM.Name, DbType.String);
            dbparams.Add("Password", password, DbType.String);
            dbparams.Add("Email", registerVM.Email, DbType.String);
            dbparams.Add("BirthDate", registerVM.BirthDate, DbType.DateTime);
            dbparams.Add("PhoneNumber", registerVM.PhoneNumber, DbType.String);
            dbparams.Add("Gender", registerVM.Gender, DbType.String);

            var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_RegisterClient]", dbparams, commandType: CommandType.StoredProcedure));

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully!"
            });
        }

        [HttpPost]
        [Route("Register/Employee")]
        public ActionResult RegisterEmployee(RegisterVM registerVM)
        {
            var password = Hashing.HashPassword(registerVM.Password);
            var dbparams = new DynamicParameters();

            dbparams.Add("Name", registerVM.Name, DbType.String);
            dbparams.Add("Password", password, DbType.String);
            dbparams.Add("Email", registerVM.Email, DbType.String);
            dbparams.Add("BirthDate", registerVM.BirthDate, DbType.DateTime);
            dbparams.Add("PhoneNumber", registerVM.PhoneNumber, DbType.String);
            dbparams.Add("Gender", registerVM.Gender, DbType.String);

            var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_RegisterEmployee]", dbparams, commandType: CommandType.StoredProcedure));

            return Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully!"
            });
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginVM loginVM)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Email", loginVM.Email, DbType.String);
            dynamic result = dapper.Get<dynamic>(
                "[dbo].[SP_Login_Client]",
                dbparams,
                CommandType.StoredProcedure
                );

            if (Hashing.ValidatePassword(loginVM.Password, result.Password))
            {
                var jwt = new JwtService(Configuration);
                var token = jwt.LoginToken(result.Email, result.Name);
                return Ok(new { token });
            }
            return BadRequest("Wrong Password");
        }

        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword([FromBody] ChangePasswordVM changePasswordVM)
        {

            //string token = Request.Headers["Token"].ToString();
            var jwt = new JwtSecurityTokenHandler();
            var jwtRead = jwt.ReadJwtToken(changePasswordVM.Token);

            var email = jwtRead.Claims.First(email => email.Type == "email").Value;
            var client = myContext.Clients.FirstOrDefault(cl => cl.Email == email);
            var clientAccount = client.AccountClient;
            if (client != null)
            {
                if (Hashing.ValidatePassword(changePasswordVM.OldPassword, clientAccount.Password))
                {
                    clientAccount.Password = Hashing.HashPassword(changePasswordVM.NewPassword);
                    var result = accountRepository.Put(clientAccount) > 0 ? (ActionResult)Ok("Data berhasil diupdate") : BadRequest("Data gagal diupdate");
                    //return result;
                    //var data = accountRepository.ChangePassword(changePasswordVM.Email, changePasswordVM.NewPassword);
                    return Ok(new { message = "Password Changed", status = "Ok" });
                }
                else
                {
                    return StatusCode(404, new { status = "404", message = "Wrong password" });
                }
            }
            return NotFound();
        }
    }
}
