using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("TB_M_TicketStatus")]
    public class TicketStatus
    {
        [Key]
        public int ID { get; set; }
        public DateTime StatusDate { get; set; }
        public Ticket Ticket { get; set; }
        public Status Status { get; set; }
    }
}