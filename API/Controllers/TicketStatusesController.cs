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
    public class TicketStatusesController : BaseController<TicketStatus, TicketStatusRepository, int>
    {
        private readonly TicketStatusRepository ticketStatusRepository;
        public TicketStatusesController(TicketStatusRepository ticketStatusRepository) : base(ticketStatusRepository)
        {
            this.ticketStatusRepository = ticketStatusRepository;
        }
    }
}
