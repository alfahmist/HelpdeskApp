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
using Microsoft.Extensions.Configuration;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly IGenericDapper dapper;
        private readonly IConfiguration Configuration;
        public EmployeeController(EmployeeRepository employeeRepository, IGenericDapper dapper, IConfiguration Configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.dapper = dapper;
            this.Configuration = Configuration;
        }
        [HttpGet("All")]
        public IEnumerable<dynamic> All()
        {
                return dapper.GetAll<dynamic>("[dbo].[SP_SelectEmployee]", null, commandType: CommandType.StoredProcedure);
        }
    }
}
