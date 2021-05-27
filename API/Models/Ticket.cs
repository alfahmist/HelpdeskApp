using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Ticket")]
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        public Category Category { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public Client Client { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        public ICollection<TicketResponse> TicketResponses { get; set; }
        public ICollection<TicketStatus> TicketStatuses { get; set; }
    }
}
