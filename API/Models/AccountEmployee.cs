using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_AccountEmployee")]
    public class AccountEmployee
    {
        [Key]
        public string ID { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }

    }
}
