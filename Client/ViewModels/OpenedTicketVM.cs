using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class OpenedTicketVM
    {
        public string TicketID { get; set; }
        public string TicketName { get; set; }
        public string Requestor { get; set; }
        public string OpenDate { get; set; }
        public string Description { get; set; }
        public string TicketSubject { get; set; }
        public string TicketMessage { get; set; }
        public string TicketStatus { get; set; }
        public string StatusDate { get; set; }
    }
}
