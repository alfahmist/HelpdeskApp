using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, MyContext, int>
    {
        private readonly MyContext myContext;

        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
