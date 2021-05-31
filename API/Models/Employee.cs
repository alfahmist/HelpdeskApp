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
        public string Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Account Account { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketResponse> TicketResponse { get; set; }
=======
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public AccountEmployee AccountEmployee { get; set; }
        public Role Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

>>>>>>> FrotnEnd/Fahmi
    }
}
