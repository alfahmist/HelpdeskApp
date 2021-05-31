using API.Base;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : BaseController<Status, StatusRepository, int>
    {
        private readonly StatusRepository statusRepository;
        public StatusesController(StatusRepository statusRepository) : base(statusRepository)
        {
            this.statusRepository = statusRepository;
        }
    }
}
