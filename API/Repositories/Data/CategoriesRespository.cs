using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class CategoriesRespository : GeneralRepository<Category, MyContext, int>
    {
        private readonly MyContext myContext;

        public CategoriesRespository(MyContext myContext) : base(myContext)
        {

        }
    }
}
