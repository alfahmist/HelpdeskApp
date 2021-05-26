﻿using API.Base;
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
    public class TicketResponsesController : BaseController<TicketResponse, TicketResponseRepository, int>
    {
        private readonly TicketResponseRepository ticketResponseRepository;
        public TicketResponsesController(TicketResponseRepository ticketResponseRepository) : base(ticketResponseRepository)
        {
            this.ticketResponseRepository = ticketResponseRepository;
        }
    }
}
