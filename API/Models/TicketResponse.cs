using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("TB_M_TicketResponse")]
    public class TicketResponse
    {
        [Key]
        public int ID { get; set; }
        public Ticket Ticket { get; set; }
        public Employee Employee { get; set; }
        public TicketResponseDetail TicketResponseDetail { get; set; }
    }

}