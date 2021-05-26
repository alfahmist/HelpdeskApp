using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController<Department, DepartmentRepository, int>
    {
        private readonly DepartmentRepository departmentRepository;
        public DepartmentsController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
    }
}
