using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_User")]
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD:API/Models/User.cs
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Departments Departments { get; set; }
        public UserAccount UserAccount { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<TicketResponse> TicketResponses { get; set; }
=======
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public Account Account { get; set; }
        public Role Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

>>>>>>> FrotnEnd/Fahmi:API/Models/Client.cs
    }
}
