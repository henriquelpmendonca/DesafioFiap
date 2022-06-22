using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GSVTestApp.Tela
{
    [TestClass]
    public class Tela_PedidoTest
    {
      

        [TestMethod]
        public void Tela_CadastrarPedidos_NovoPedido()
        {
            Util util = new Util(true);
            util.InstanciaSeleniumLocalHost("CadastrarPedido/2");
            util.PrencherCampoText("txtNome");
            util.PrencherCampoText("txtEmail", $"Teste{util.GerarIntAleatorio(1,999)}@teste.com");
            util.SelecionarComboByText("drpTipoAssinatura", "Gold");
            util.ClicarBotao("btnSalvarPedido");
            Assert.AreEqual(util.RetornaValorElemento("alertSucess"), "Pedido Enviado com Sucesso!");
            util.driver.Quit();
        }


        [TestMethod]
        public void Tela_EditarPedidos_EditarPedido()
        {
            Util util = new Util(true);
            util.InstanciaSeleniumLocalHost("pedidos");
            util.ClicarBotao("btnEditarPedido");
            util.PrencherCampoText("txtNome");
            util.PrencherCampoText("txtEmail", $"Teste{util.GerarIntAleatorio(1, 999)}@teste.com");
            util.SelecionarComboByText("drpTipoAssinatura", "Silver");
            util.PrencherCampoData("txtdataSolicitacao", 5);
            util.ClicarBotao("btnSalvarPedido");
            util.driver.Quit();
        }

        [TestMethod]
        public void Tela_Pedidos_ExcluirPedido()
        {
            Util util = new Util(true);
            util.InstanciaSeleniumLocalHost("pedidos");
            var valor = util.RetornarQuantidadeRegistrosGrid("gridPedidos");
            util.ClicarBotao("btnExcluirPedido");
            var valor2 = util.RetornarQuantidadeRegistrosGrid("gridPedidos");
            Assert.AreEqual(valor - 1, valor2);
            util.driver.Quit();
        }




    }
}
