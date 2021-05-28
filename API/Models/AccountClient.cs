using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_AccountClient")]
    public class AccountClient
    {
        [Key]
        public string ID { get; set; }
        public string Password { get; set; }
        public Client Client { get; set; }
    }
}
