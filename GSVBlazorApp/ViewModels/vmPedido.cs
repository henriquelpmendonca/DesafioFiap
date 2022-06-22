using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSVBlazorApp.ViewModels
{
    public class vmPedido
    {
        public int PedidoId { get; set; }
        [Required(ErrorMessage = "Favor Prencher Nome!")]
        [StringLength(100, ErrorMessage = "Campo Permitido somente 100 Caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Favor Prencher E-mail!")]
        [EmailAddress(ErrorMessage ="Favor Prencher com E-mail Valido!")]
        [StringLength(100, ErrorMessage = "Campo Permitido somente 100 Caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor Prencher um Tipo de Assinatura!")]
        public string TipoAssinatura { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public bool Status { get; set; }
    }
}
