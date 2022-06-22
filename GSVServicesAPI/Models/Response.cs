using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSVServicesAPI.Models
{
    public class Response
    {
        public string Mensagem { get; set; }
        public bool StatusRequest { get; set; }
        public dynamic objeto { get; set; }
    }
}
