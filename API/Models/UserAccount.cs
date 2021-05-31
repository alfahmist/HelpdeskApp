using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
<<<<<<< HEAD:API/Models/UserAccount.cs
    [Table("TB_M_UserAccount")]
    public class UserAccount
=======
    [Table("TB_M_AccountClient")]
    public class Account
>>>>>>> FrotnEnd/Fahmi:API/Models/Account.cs
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
<<<<<<< HEAD:API/Models/UserAccount.cs
        public User User { get; set; }
=======
        public Client Client{ get; set; }
>>>>>>> FrotnEnd/Fahmi:API/Models/Account.cs

    }
}
