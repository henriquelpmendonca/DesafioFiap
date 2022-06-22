using GSVServicesAPI;
using GSVServicesAPI.Models;
using GSVServicesAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSVTestApp.Integrados
{
    [TestClass]
    public class Integrado_PedidoTest
    {
        [TestMethod]
        public void RepositorioPedido_OperacaoCreate()
        {
            try
            {
                Util util = new Util();
                var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
                var repo = webHost.Services.GetRequiredService<IRepository<Pedido>>();

                var obj = new Pedido()
                {
                    Nome = $"Produto Teste Integrado {util.GerarIntAleatorio(1, 999)}",
                    Email = $"{util.GerarIntAleatorio(1, 999)}Teste@Teste.com",
                    Status = true,
                    dataSolicitacao = DateTime.Now,
                    TipoAssinatura = "Gold"
                };

                var newId = repo.Create(obj);
                Pedido pedido = repo.GetById(newId.Result).Result;

                Assert.AreEqual(obj.Nome, pedido.Nome);
                Assert.AreEqual(obj.Email, pedido.Email);
                Assert.AreEqual(obj.Status, pedido.Status);
                Assert.AreEqual(obj.TipoAssinatura, pedido.TipoAssinatura);

            }
            catch (System.Exception ex)
            {
                Assert.Fail();
                throw ex;
            }
        }

        [TestMethod]
        public void RepositorioPedido_OperacaoAtualizar()
        {
            try
            {
                Util util = new Util();
                var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
                var repo = webHost.Services.GetRequiredService<IRepository<Pedido>>();

                var id = repo.ListAll().Result[0].PedidoId;
                var obj = new Pedido()
                {
                    PedidoId = id,
                    Nome = $"Produto Teste Integrado {util.GerarIntAleatorio(1, 999)}",
                    Email = $"{util.GerarIntAleatorio(1, 999)}Teste@Teste.com",
                    Status = true,
                    dataSolicitacao = DateTime.Now,
                    TipoAssinatura = "Gold"
                };
                
                repo.Update(obj);
                Pedido pedido = repo.GetById(id).Result;

                Assert.AreEqual(obj.Nome, pedido.Nome);
                Assert.AreEqual(obj.Email, pedido.Email);
                Assert.AreEqual(obj.Status, pedido.Status);
                Assert.AreEqual(obj.TipoAssinatura, pedido.TipoAssinatura);
            }
            catch (System.Exception ex)
            {
                Assert.Fail();
                throw ex;
            }

        }





    }
}
