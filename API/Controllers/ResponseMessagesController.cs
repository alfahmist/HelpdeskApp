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
    public class ResponseMessagesController : BaseController<ResponseMessage, ResponseMessageRepository, int>
    {
        private readonly ResponseMessageRepository responseMessageRepository;
        public ResponseMessagesController(ResponseMessageRepository responseMessageRepository) : base(responseMessageRepository)
        {
            this.responseMessageRepository = responseMessageRepository;
        }
    }
}
