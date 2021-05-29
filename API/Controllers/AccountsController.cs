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
    public class AccountsController : BaseController<Account, AccountRepository, int>
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
            string url = "https://localhost:44397/";
            //sender
            var user = new SmtpClient("smtp.gmail.com", 587) //bikin 1 handler sendiri
            {
                UseDefaultCredentials = true,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(sender, pwd),
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
                var client = myContext.Accounts.FirstOrDefault(x => x.Employee.Email == email);
                if (client == null)
                {
                    return NotFound();
                }

                // Bcrypt
                client.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                // Update
                var result = accountRepository.Put(client) > 0 ? (ActionResult)Ok("Password has been updated") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (ArgumentException)
            {
                return Unauthorized(new { Status = "Failed", Message = "Link is expired" });
            }
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult RegisterEmployee(RegisterEmployeeVM registerVM)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password);
            var dbparams = new DynamicParameters();

            dbparams.Add("Name", registerVM.Name, DbType.String);
            dbparams.Add("Password", password, DbType.String);
            dbparams.Add("Email", registerVM.Email, DbType.String);
            dbparams.Add("BirthDate", registerVM.BirthDate, DbType.DateTime);
            dbparams.Add("PhoneNumber", registerVM.PhoneNumber, DbType.String);
            dbparams.Add("Gender", registerVM.Gender, DbType.String);
            dbparams.Add("Role", registerVM.Role, DbType.Int32);
            dbparams.Add("Department", registerVM.Department, DbType.Int32);

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
                "[dbo].[SP_LoginClient]",
                dbparams,
                CommandType.StoredProcedure
                );

            if (BCrypt.Net.BCrypt.Verify(loginVM.Password, result.Password))
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
            var client = myContext.Accounts.FirstOrDefault(cl => cl.Employee.Email == email);
            //var clientAccount = client.Account;
            if (client != null)
            {
                if (BCrypt.Net.BCrypt.Verify(changePasswordVM.OldPassword, client.Password))
                {
                    client.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordVM.NewPassword);
                    var result = accountRepository.Put(client) > 0 ? (ActionResult)Ok("Data berhasil diupdate") : BadRequest("Data gagal diupdate");
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
