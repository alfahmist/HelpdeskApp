using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class ResponseMessageRepository : GeneralRepository<ResponseMessage, MyContext, int>
    {
        private readonly MyContext myContext;

        public ResponseMessageRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
