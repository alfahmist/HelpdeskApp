using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
<<<<<<< HEAD:API/Models/TicketMessage.cs
    [Table("TB_T_TicketMessage")]
    public class TicketMessage
    {
        [Key]
        public int Id { get; set; }
=======
    [Table("TB_M_ClientMessage")]
    public class ClientMessage
    {
        [Key]
        public string ID { get; set; }
>>>>>>> FrotnEnd/Fahmi:API/Models/ClientMessage.cs
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public Ticket Ticket { get; set; }

    }
}
