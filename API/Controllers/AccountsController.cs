using API.Base;
using API.Context;
//Hashing
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
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, int>
    {
        private readonly AccountRepository accountRepository;
        private readonly IGenericDapper dapper;
        private readonly MyContext myContext;
        private IConfiguration Configuration;
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

            var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_Register]", dbparams, commandType: CommandType.StoredProcedure));

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
                "[dbo].[SP_Login]",
                dbparams,
                CommandType.StoredProcedure
                );

            if (Hashing.ValidatePassword(loginVM.Password, result.Password))
            {
                var jwt = new JwtService(Configuration);
                var token = jwt.GenerateSecurityToken(result.Name, result.Email);
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
            var account = myContext.Accounts.FirstOrDefault(account => account.Client.Email == email);
            if (account != null)
            {
                if (Hashing.ValidatePassword(changePasswordVM.OldPassword, account.Password))
                {
                    account.Password = Hashing.HashPassword(changePasswordVM.NewPassword);
                    var result = accountRepository.Put(account) > 0 ? (ActionResult)Ok("Data berhasil diupdate") : BadRequest("Data gagal diupdate");
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
