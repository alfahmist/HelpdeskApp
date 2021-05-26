using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class StatusRepository : GeneralRepository<Status, MyContext, int>
    {
        private readonly MyContext myContext;

        public StatusRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
