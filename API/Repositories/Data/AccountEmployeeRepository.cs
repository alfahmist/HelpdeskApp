using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class AccountEmployeeRepository : GeneralRepository<AccountEmployee, MyContext, int>
    {
        private readonly MyContext myContext;

        public AccountEmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
