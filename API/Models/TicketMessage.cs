using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_TicketMessage")]
    public class TicketMessage
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Ticket Ticket { get; set; }
    }
}
