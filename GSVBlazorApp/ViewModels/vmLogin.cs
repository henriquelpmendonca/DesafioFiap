using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSVBlazorApp.ViewModels
{
    public class vmLogin
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Favor Prencher o campo Usuário!")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Favor Prencher o campo Senha!")]
        public string Senha { get; set; }
    }
}
