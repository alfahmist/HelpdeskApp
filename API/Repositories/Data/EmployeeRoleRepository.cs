using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRoleRepository : GeneralRepository<EmployeeRole, MyContext, int>
    {
        private readonly MyContext myContext;

        public EmployeeRoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
