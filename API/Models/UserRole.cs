using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_UserRole")]
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
