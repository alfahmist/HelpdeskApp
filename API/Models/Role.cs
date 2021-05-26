using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Role")]
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
