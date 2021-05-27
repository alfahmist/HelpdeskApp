using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("TB_M_TicketResponseDetail")]
    public class TicketResponseDetail
    {
        [Key]
        public int ID { get; set; }
        public string Solution { get; set; }
        public string Detail { get; set; }
        public DateTime ResponseDate { get; set; }
        public TicketResponse TicketResponse { get; set; }
    }
}