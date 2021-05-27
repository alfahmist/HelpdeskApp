using System;
using System.Collections.Generic;
//For Required
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Tidak boleh kosong")]
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
