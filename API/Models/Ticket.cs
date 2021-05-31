using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_Ticket")]
    public class Ticket
    {
        [Key]
<<<<<<< HEAD
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Categories Categories { get; set; }
        public Employee Employee { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        public ICollection<TicketStatus> TicketStatuses { get; set; }
        public ICollection<TicketResponse> TicketResponses { get; set; }
=======
        public string ID { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public ClientMessage ClientMessage { get; set; }
        public ResponseMessage Response { get; set; }
        public Status Status { get; set; }
>>>>>>> FrotnEnd/Fahmi
    }
}
