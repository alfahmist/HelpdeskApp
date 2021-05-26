using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("TB_M_TicketStatus")]
    public class TicketStatus
    {
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public Status Status { get; set; }
    }
}