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
    public class TicketMessagesController : BaseController<TicketMessage, TicketMessageRepository, int>
    {
        private readonly TicketMessageRepository ticketMessageRepository;
        public TicketMessagesController(TicketMessageRepository ticketMessageRepository) : base(ticketMessageRepository)
        {
            this.ticketMessageRepository = ticketMessageRepository;
        }
    }
}
