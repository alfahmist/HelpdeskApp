using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoriesRespository, int>
    {
        private readonly CategoriesRespository categoryRepository;
        public CategoriesController(CategoriesRespository categoryRepository) : base(categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}
