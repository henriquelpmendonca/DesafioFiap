using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSVServicesAPI.Busniness;
using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GSVServicesAPI.Controllers
{
    [Route("Pedido")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        public int FromServices { get; private set; }

        [HttpDelete]
        [Route("DeletaPedido/{idPedido:int}")]
        public async Task<bool> Delete([FromServices]IRepository<Pedido> repo, int idPedido)
        {
            BusninessPedido bus = new BusninessPedido(repo);
            return await bus.ExcluirPedido(idPedido);
        }

        [HttpGet]
        [Route("ListarPedidos")]
        public async Task<List<Pedido>> get([FromServices] BusninessPedido bus)
        {
            return await bus.ListarPedidos();
        }

        [HttpGet]
        [Route("ListarPedidos/{PedidoId:int}")]
        public async Task<Pedido> get([FromServices] BusninessPedido bus, int PedidoId)
        {

            return await bus.GetPedidoById(PedidoId);
        }
        [HttpPost]
        [Route("CadastrarPedido")]
        public async Task<Response> Post([FromServices] BusninessPedido bus, [FromBody] Pedido pedido)
        {
            if (!pedido.Equals(null))
            {
                try
                {
                    var retorno = await bus.CadastrarPedido(pedido);
                    if (retorno)
                        return new Response()
                        {
                            Mensagem = "Pedido Enviado com Sucesso!",
                            StatusRequest = true,
                        };
                }
                catch (Exception ex)
                {
                    return new Response()
                    {
                        Mensagem = ex.Message,
                        StatusRequest = false,
                    };
                }
            }
            return new Response()
            {
                Mensagem = "Erro Dado não prenchido!",
                StatusRequest = false,
            };
        }

        [HttpPost]
        [Route("AtualizarPedido")]
        public async Task<Response> AtualizarPedido([FromServices] BusninessPedido bus, [FromBody] Pedido pedido)
        {
            if (!pedido.Equals(null))
            {
                try
                {
                    var retorno = await bus.AtualizarPedido(pedido);
                    if (retorno)
                        return new Response()
                        {
                            Mensagem = "Pedido Enviado com Sucesso!",
                            StatusRequest = true,
                        };
                }
                catch (Exception ex)
                {
                    return new Response()
                    {
                        Mensagem = ex.Message,
                        StatusRequest = false,
                    };
                }
            }
            return new Response()
            {
                Mensagem = "Erro Dado não prenchido!",
                StatusRequest = false,
            };

        }
    }
}