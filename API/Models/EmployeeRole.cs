using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_EmployeeRole")]
    public class EmployeeRole
    {
        [Key]
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
