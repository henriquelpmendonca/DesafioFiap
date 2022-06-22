using System;

namespace GSVServicesAPI.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoAssinatura { get; set; }
        public DateTime dataSolicitacao { get; set; }
        public bool Status { get; set; }
    }
}
