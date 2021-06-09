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
using API.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace API.Controllers

{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly IGenericDapper dapper;
        private readonly EmployeeRepository employeeRepository;
        private IConfiguration Configuration;
        public EmployeeController(EmployeeRepository employeeRepository, IConfiguration Configuration, IGenericDapper dapper) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.Configuration = Configuration;
            this.dapper = dapper;
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
       
        [HttpGet("All")]
        public IEnumerable<dynamic> All()
        {
                return dapper.GetAll<dynamic>("[dbo].[SP_SelectEmployee]", null, commandType: CommandType.StoredProcedure);
        }
    }
}
