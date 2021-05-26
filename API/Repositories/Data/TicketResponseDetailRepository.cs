using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    
    public class TicketResponseDetailRepository : GeneralRepository<TicketResponseDetail, MyContext, int>
    {
        private readonly MyContext myContext;

        public TicketResponseDetailRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
