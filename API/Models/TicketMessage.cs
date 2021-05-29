using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Table_T_TicketMessage")]
    public class TicketMessage
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public Ticket Ticket { get; set; }

    }
}
