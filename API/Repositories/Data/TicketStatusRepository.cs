using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class TicketStatusRepository : GeneralRepository<TicketStatus, MyContext, int>
    {
        private readonly MyContext myContext;

        public TicketStatusRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
