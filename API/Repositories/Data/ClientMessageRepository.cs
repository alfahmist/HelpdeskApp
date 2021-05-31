using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class ClientMessageRepository : GeneralRepository<ClientMessage, MyContext, string>
    {
        private readonly MyContext myContext;

        public ClientMessageRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
