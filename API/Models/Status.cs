using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Table_M_Status")]
    public class Status
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StatusDate { get; set; }
        public string Description { get; set; }
        public ICollection<TicketStatus> TicketStatuses { get; set; }
    }
}
