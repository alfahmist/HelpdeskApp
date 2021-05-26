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
    public class TicketResponseDetailController : BaseController<TicketResponseDetail, TicketResponseDetailRepository, int>
    {
        private readonly TicketResponseDetailRepository ticketResponseDetailRepository;
        public TicketResponseDetailController(TicketResponseDetailRepository ticketResponseDetailRepository) : base(ticketResponseDetailRepository)
        {
            this.ticketResponseDetailRepository = ticketResponseDetailRepository;
        }
    }
}
