using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class CreateTicketVM
    {
        public string TicketName { get; set; }
        public string ClientId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int CategoriesId { get; set; }
    }
}
