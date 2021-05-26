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
    public class ClientsController : BaseController<Client, ClientRepository, int>
    {
        private readonly ClientRepository clientRepository;
        public ClientsController(ClientRepository clientRepository) : base(clientRepository)
        {
            this.clientRepository = clientRepository;
        }
    }
}
