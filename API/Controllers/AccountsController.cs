using API.Base;
using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private readonly AccountRepository accountRepository;
        private readonly IConfiguration config;
        MyContext myContext;
        public AccountsController(AccountRepository accountRepository, IConfiguration config, MyContext myContext) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.config = config;
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

            var jwt = new JwtService(config);
            string token = jwt.ForgotToken(email);
            MailMessage message = new MailMessage(sender, email);
            message.Subject = "Reset Password Request";
            message.Body = $"{url}{token}";
            user.Send(message);
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
                var account = myContext.Clients.FirstOrDefault(x => x.Email == email).Account;
                if(account == null)
                {
                    return NotFound();
                }
                // Bcrypt
                account.Password = newPassword;

                // Update
                var result = accountRepository.Put(account) > 0 ? (ActionResult)Ok("Password has been updated") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (ArgumentException)
            {
                return Unauthorized(new { Status = "Failed", Message = "Link is expired" });
            }
        }
    }
}
