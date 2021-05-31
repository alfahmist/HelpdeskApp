using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class TicketResponseRepository : GeneralRepository<TicketResponse, MyContext, int>
    {
        private readonly MyContext myContext;

        public TicketResponseRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
