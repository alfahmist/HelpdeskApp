using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
<<<<<<< HEAD:API/Models/TicketStatus.cs
    [Table("TB_T_TicketStatus")]
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }
        public DateTime StatusDate { get; set; }
=======
    [Table("TB_M_Response")]
    public class ResponseMessage
    {
        [Key]
        public string ID { get; set; }
>>>>>>> FrotnEnd/Fahmi:API/Models/ResponseMessage.cs
        public Ticket Ticket { get; set; }
        public string Message { get; set; }
        public DateTime ResponseDate { get; set; }

    }
<<<<<<< HEAD:API/Models/TicketStatus.cs
}
=======

}
>>>>>>> FrotnEnd/Fahmi:API/Models/ResponseMessage.cs
