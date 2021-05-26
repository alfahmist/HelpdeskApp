using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, MyContext, int>
    {
        private readonly MyContext myContext;

        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
