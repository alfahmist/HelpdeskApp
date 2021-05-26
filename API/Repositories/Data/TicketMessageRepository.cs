using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class TicketMessageRepository : GeneralRepository<TicketMessage, MyContext, int>
    {
        private readonly MyContext myContext;

        public TicketMessageRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
