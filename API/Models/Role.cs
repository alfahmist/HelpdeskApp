using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
        public ICollection<Employee> Employee { get; set; }
=======
        public ICollection<Employee> employees { get; set; }
        public ICollection<Client> clients { get; set; }
>>>>>>> FrotnEnd/Fahmi

    }
}
