using API.Base;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.Context;
using Microsoft.Extensions.Configuration;
using API.ViewModel;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using API.Handler;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : BaseController<Ticket, TicketRepository, string>
    {
        private readonly TicketRepository ticketRepository;
        private readonly IGenericDapper dapper;
        private readonly MyContext myContext;
        private IConfiguration Configuration;
        public TicketsController (TicketRepository ticketRepository,
            IConfiguration Configuration,
            IGenericDapper dapper,
            MyContext myContext) : base(ticketRepository)
        {
            this.ticketRepository = ticketRepository;
            this.Configuration = Configuration;
            this.dapper = dapper;
            this.myContext = myContext;
        }

        [HttpPost]
        [Route("CreateTicket")]
        public ActionResult CreateTicket([FromBody] CreateTicketVM ticketVM)
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("Name", ticketVM.TicketName, DbType.String);
            dbparams.Add("ClientId", ticketVM.ClientId, DbType.String);
            dbparams.Add("CategoriesId", ticketVM.CategoriesId, DbType.Int32);
            dbparams.Add("Subject", ticketVM.Subject, DbType.String);
            dbparams.Add("Message", ticketVM.Message, DbType.String);

            var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_CreateTicket]", dbparams, commandType: CommandType.StoredProcedure));


            var client = myContext.Employees.FirstOrDefault(x => x.Id == ticketVM.ClientId);
            var email = client.Email;
            var subject = ticketVM.Subject;
            var ticketName = ticketVM.TicketName;
            var message = ticketVM.Message;

            string sender = "aninsabrina17@gmail.com";
            string pwd = "yulisulasta";

            //sender
            var user = new SmtpClient("smtp.gmail.com", 587) //bikin 1 handler sendiri
            {
                UseDefaultCredentials = true,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(sender, pwd),
            };

            CreateTicketEmailHandler mailHandler = new CreateTicketEmailHandler(sender, email, subject, ticketName, message);
            user.Send(mailHandler.Message());
            return Ok(new Response
            {
                Status = "Success",
                Message = "Ticket created successfully!"
            });
        }
        
        [HttpPost]
        [Route("ResponseTicket")]
        public ActionResult ResponseTicket([FromBody] TicketResponseVM ResponseVM)
        {
            var dbparams =  new DynamicParameters();

            dbparams.Add("TicketId", ResponseVM.TicketId, DbType.String);
            dbparams.Add("Solution", ResponseVM.Solution, DbType.String);
            dbparams.Add("EmployeeId", ResponseVM.EmployeeId, DbType.String);

            var parm = new DynamicParameters();
            parm.Add("TicketId", ResponseVM.TicketId, DbType.String);
            dynamic dataEmail = dapper.Get<dynamic>(
                "[dbo].[SP_RetrieveEmail]",
                parm,
                CommandType.StoredProcedure
                );

            var client = myContext.Tickets.FirstOrDefault(x => x.Id == ResponseVM.TicketId);
            var ticketSubject = client.Name;
            var ticketId = ResponseVM.TicketId;
            var solution = ResponseVM.Solution;

            string sender = "aninsabrina17@gmail.com";
            string pwd = "yulisulasta";

            //sender
            var user = new SmtpClient("smtp.gmail.com", 587) //bikin 1 handler sendiri
            {
                UseDefaultCredentials = true,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(sender, pwd),
            };

            CreateSolutionEmailHandler mailHandler = new CreateSolutionEmailHandler(sender, dataEmail.Email, ticketId, ticketSubject, solution);
            user.Send(mailHandler.Message());


            return Ok(new Response
            {
                Status = "Success",
                Message = "Ticket Just Responsed successfully!"
            });
        }

        //[AllowAnonymous]
        [HttpGet("GetOpenTickets")]
        public IEnumerable<dynamic> GetOpenTickets()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("statusId", 1, DbType.String);
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetStatusByID]", dbparams, commandType: CommandType.StoredProcedure);
        }
        
        [AllowAnonymous]
        [HttpGet("GetResponsedTickets")]
        public IEnumerable<dynamic> GetResponsedTickets()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("statusId", 3, DbType.String);
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetStatusByID]", dbparams, commandType: CommandType.StoredProcedure);
        }
        
        [AllowAnonymous]
        [HttpGet("GetInprogressTickets")]
        public IEnumerable<dynamic> GetInprogressTickets()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("statusId", 2, DbType.String);
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetStatusByID]", dbparams, commandType: CommandType.StoredProcedure);
        }
        
        [HttpGet("GetAllTicketUpdates")]
        public IEnumerable<dynamic> GetAllTicketUpdates()
        {
            var dbparams = new DynamicParameters();
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetAllLatestTicket]", dbparams, commandType: CommandType.StoredProcedure);
        }

       
        [AllowAnonymous]
        [HttpGet("Latest-Ticket-Status/{clientId}")]
        public IActionResult TicketUpdates(string clientId)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ClientId", clientId, DbType.String);
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            dynamic result =  db.Query<dynamic>("[dbo].[SP_GetLatestTicketStatus]", dbparams, commandType: CommandType.StoredProcedure);
            return Ok(result);
        }

        //[AllowAnonymous]
        //[HttpPost("GetALL-Ticket-Newest-Updates")]
        //public IEnumerable<dynamic> GetAllNewTIcketUpdates()
        //{
        //    var dbparams = new DynamicParameters(); 
        //    using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
        //    return db.Query<dynamic>("[dbo].[SP_GetAllNewestTicket]", dbparams, commandType: CommandType.StoredProcedure);
        //}

        [HttpPost]
        [Route("UpdateStatusTicket")]
        public ActionResult UpdateTicketStatus([FromBody] InputTicketStatusVM inputTicketStatusVM)
        {
            var dbparams = new DynamicParameters();

            dbparams.Add("TicketId", inputTicketStatusVM.TicketId, DbType.String);
            //dbparams.Add("StatusId", inputTicketStatusVM.StatusId, DbType.Int32);

            var result = Task.FromResult(dapper.Insert<int>("[dbo].[SP_CloseTicket]", dbparams, commandType: CommandType.StoredProcedure));

            return Ok(new Response
            {
                Status = "Success",
                Message = "Ticket Just Updated It's Status successfully!"
            });
        }

        [AllowAnonymous]
        [HttpPost("GetTicketById")]
        public ActionResult GetTicketById([FromBody] TicketById ticketById)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("TicketId", ticketById.TicketId, DbType.String);
            dynamic result = dapper.Get<dynamic>(
                "[dbo].[SP_TicketDetailById]",
                dbparams,
                CommandType.StoredProcedure
                );
            return Ok(result);
        }
    }
}
