﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class InprogressTicketVM
    {
        public string TicketID { get; set; }
        public string TicketName { get; set; }
        public string Category { get; set; }
        public string StatusDate { get; set; }
        public string RequestorName { get; set; }
        public string TicketDate { get; set; }
        public string TicketStatus { get; set; }
    }
}
