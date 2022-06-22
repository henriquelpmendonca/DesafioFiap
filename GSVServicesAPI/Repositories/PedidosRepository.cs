using Dapper;
using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GSVServicesAPI.Repositories
{
    public class PedidosRepository : IRepository<Pedido>
    {
        private readonly IDapperOperacoes _dapper;
        public PedidosRepository(IDapperOperacoes dapper)
        {
            this._dapper = dapper;
        }

        public async Task<int> Create(Pedido Model)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Nome", Model.Nome, DbType.String);
            dbPara.Add("Email", Model.Email, DbType.String);
            dbPara.Add("Status", Model.Status, DbType.Boolean);
            dbPara.Add("TipoAssinatura", Model.TipoAssinatura, DbType.String);
            dbPara.Add("dataSolicitacao", Model.dataSolicitacao, DbType.DateTime);
            
            var produtoId = await Task.FromResult(_dapper.Insert<int>("[dbo].[prNovoPedido]",
                dbPara,
                commandType: CommandType.StoredProcedure));

            return produtoId;
        }

        public async Task<int> Delete(int Id)
        {
            var produto = await Task.FromResult(_dapper.Execute($"delete from [Tb_Pedidos] where PedidoId = {Id}", null,
              commandType: CommandType.Text));
            return produto;
        }

        public async Task<int> Update(Pedido Model)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Nome", Model.Nome, DbType.String);
            dbPara.Add("Email", Model.Email, DbType.String);
            dbPara.Add("Status", Model.Status, DbType.Boolean);
            dbPara.Add("TipoAssinatura", Model.TipoAssinatura, DbType.String);
            dbPara.Add("dataSolicitacao", Model.dataSolicitacao, DbType.DateTime);
            dbPara.Add("PedidoId", Model.PedidoId, DbType.Int32);

            var produtoId = await Task.FromResult(_dapper.Update<int>("[dbo].[prAtualizarPedido]",
                dbPara,
                commandType: CommandType.StoredProcedure));

            return produtoId;
        }

        public async Task<Pedido> GetById(int Id)
        {
            var produto = await Task.FromResult(_dapper.Get<Pedido>($"select * from [Tb_Pedidos] where PedidoId = {Id}", null,
               commandType: CommandType.Text));
            return produto;
        }

        public async Task<List<Pedido>> ListAll()
        {
            var produtos = await Task.FromResult(_dapper.GetAll<Pedido>($"select * from [Tb_Pedidos]", null,
              commandType: CommandType.Text));

            return produtos;
        }
    }
}
