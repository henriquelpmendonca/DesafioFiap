using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSVServicesAPI.Busniness
{
    public class BusninessPedido
    {
        private readonly IRepository<Pedido> _repo;

        #region Metodos de Negocio com Validações e chamadas aos Repositorys
        public BusninessPedido(IRepository<Pedido> repo)
        {
            this._repo = repo;
        }

      

        public async Task<bool> CadastrarPedido(Pedido pedido)
        {
            try
            {
                await ValidarPrenchimentoPedido(pedido);
                await VerificarQuantidadePedidos(pedido);
                await ValidarDuplicidadePedido(pedido,false);
                await _repo.Create(pedido);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        public async Task<bool> AtualizarPedido(Pedido pedido)
        {
            try
            {
                await ValidarPrenchimentoPedido(pedido);
                await ValidarDuplicidadePedido(pedido,true);
                await _repo.Update(pedido);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirPedido(int idPedido)
        {
                await _repo.Delete(idPedido);
                return true;
        }

        public async Task<Pedido> GetPedidoById(int idPedido)
        {
              return  await _repo.GetById(idPedido);
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            return await _repo.ListAll();
        }
        #endregion

        #region Metodos privados exclusivos para logica de negocio

        private async Task ValidarDuplicidadePedido(Pedido pedido, bool Atualizacao)
        {
            try
            {
                var lista = ListarPedidos().Result;
                
                var pedidoConsulta = lista.Find(x => x.Email.ToLower().Replace(" ", "") == pedido.Email.ToLower().Replace(" ", "") 
                && x.PedidoId != pedido.PedidoId 
                && x.Status == true);

                if (pedidoConsulta != null && await VerificarUpgradeAssinatura(pedido,pedidoConsulta, Atualizacao)) throw new Exception("E-mail ja cadastrado na Base");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> VerificarUpgradeAssinatura(Pedido pedidoEnviado, Pedido pedidoEncontrado, bool Atualizacao)
        {
                if (!pedidoEnviado.TipoAssinatura.Equals(pedidoEncontrado.TipoAssinatura))
                {
                     pedidoEncontrado.Status = false;
                     await AtualizarPedido(pedidoEncontrado);
                    return false;
                }

            return true;
        }



        private async Task ValidarPrenchimentoPedido(Pedido pedido)
        {
            try
            {
                if (pedido.Email.Trim().Length < 0)
                    throw new Exception("Erro Interno, E-mail não enviado ao Pedido");

                if (pedido.Nome.Trim().Length <= 0)
                    throw new Exception("Erro Interno, Nome não enviado ao Pedido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private async Task VerificarQuantidadePedidos(Pedido pedido)
        {
            try
            {

                var lista = (await ListarPedidos());
                var pedidoConsulta =  lista.FindAll(x => x.Email.ToLower().Replace(" ", "") == pedido.Email.ToLower().Replace(" ", ""));
                if (pedidoConsulta.Count >= 3) throw new Exception("Solicitação de E-mail, enviado mais que três vezes, caso precise atualizar o tipo de assinatura contate o Administrador!");
                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}