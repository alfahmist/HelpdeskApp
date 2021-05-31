using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_UserAccount")]
    public class UserAccount
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

    }
}
