using API.Base;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Data;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        private IConfiguration Configuration;
        public EmployeeController(EmployeeRepository employeeRepository, IConfiguration Configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.Configuration = Configuration;
        }
        

        [HttpGet("GetEmployee")]
        public IEnumerable<dynamic> GetEmployee()
        {

            var dbparams = new DynamicParameters();
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetEmployee]", dbparams, commandType: CommandType.StoredProcedure);
           
        }
        [HttpGet("GetOpenTickets")]
        public IEnumerable<dynamic> GetOpenTickets()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("statusId", 1, DbType.String);
            using IDbConnection db = new SqlConnection(Configuration.GetConnectionString("MyConnection"));
            return db.Query<dynamic>("[dbo].[SP_GetStatusByID]", dbparams, commandType: CommandType.StoredProcedure);
        }
    }
}
