using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class ClosedTicketVM
    {
		public string TicketId { get; set; }
		public string Description { get; set; }
		public string TicketSubject { get; set; }
		public string TicketMessage { get; set; }
		public string OpenDate { get; set; }
		public string RequestorID { get; set; }
		public string RequestorName { get; set; }
		public string Status { get; set; }
		public string StatusDate { get; set; }
		public string Solution { get; set; }
		public string SolutionDate { get; set; }
		public string RespondanceName { get; set; }
    }
}