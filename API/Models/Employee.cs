using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Account Account { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public ICollection<TicketResponse> TicketResponses { get; set; }

    }
}
