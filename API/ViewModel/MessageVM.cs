using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class MessageVM
    {
        public string ClientID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
    }
}
