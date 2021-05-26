using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class ClientRepository : GeneralRepository<Client, MyContext, int>
    {
        private readonly MyContext myContext;

        public ClientRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
