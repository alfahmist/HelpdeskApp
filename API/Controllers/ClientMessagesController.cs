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
    public class ClientMessagesController : BaseController<ClientMessage
        , ClientMessageRepository, string>
    {
        private readonly ClientMessageRepository clientMessageRepository;
        public ClientMessagesController(ClientMessageRepository clientMessageRepository) : base(clientMessageRepository)
        {
            this.clientMessageRepository = clientMessageRepository;
        }
    }
}
