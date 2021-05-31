using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_TicketStatus")]
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }
        public DateTime StatusDate { get; set; }
        public Ticket Ticket { get; set; }
        public Status Status { get; set; }
    }
}
