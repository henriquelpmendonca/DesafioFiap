using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSVBlazorApp.ViewModels
{
    public class vmResponse
    {
        public string Mensagem { get; set; }
        public bool StatusRequest { get; set; }
        public dynamic objeto { get; set; }
    }
}
