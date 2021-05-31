using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class CategoriesRepository : GeneralRepository<Categories, MyContext, int>
    {
        private readonly MyContext myContext;

        public CategoriesRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
