using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSVServicesAPI.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
