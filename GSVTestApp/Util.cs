using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GSVTestApp
{
    public  class Util
    {
        public IWebDriver driver;

        public Util(bool testeTela = false)
        {
            if (testeTela)
            {
                this.driver = new ChromeDriver();
            }
        }

        public  int GerarIntAleatorio(int primeiro, int ultimo)
        {
            try
            {
                return new Random().Next(primeiro, ultimo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public  string GerarGuid()
        {
            return Guid.NewGuid().ToString();
        }


        /// <summary>
        /// Gera uma InstanciaSeleniumLocal 
        /// </summary>
        public IWebDriver InstanciaSeleniumLocalHost(string url)
        {
            try
            {
                driver.Navigate().GoToUrl($"https://localhost:44380/{url}");
                driver.Manage().Window.FullScreen();
                return driver;
            }
            catch (Exception ex)
            {
                driver.Quit();
                throw ex;
            }
        }

        /// <summary>
        /// Prenche campo com texto com parametro e retorna um IWebElement
        /// </summary>
        public IWebElement PrencherCampoText(string idElemento, string valor = "")
        {
            try
            {

                if (valor.Equals("")) { valor = $"Teste Automatizado {GerarIntAleatorio(1, 999999)}"; }
                var campo = MoverTelaAteElementoVisivel(idElemento);
                campo.Clear();
                campo.SendKeys(valor);
                return campo;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }

        /// <summary>
        /// Prenche campo com Datetime.Now e retorna um IWebElement
        /// </summary>
        public IWebElement PrencherCampoData(string idElemento)
        {
            try
            {
                var campo = MoverTelaAteElementoVisivel(idElemento);
                var data = DateTime.Now;
                campo.SendKeys(data.ToString());
                return campo;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }

        /// <summary>
        /// Prenche campo com Datetime.Now e acrecimos de dias e retorna um IWebElement
        /// </summary>
        public IWebElement PrencherCampoData(string idElemento, int dias)
        {
            try
            {
                var campo = MoverTelaAteElementoVisivel(idElemento);
                var data = DateTime.Now.AddDays(dias);

                campo.SendKeys(data.ToString());
                return campo;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }

        
  
        public IWebElement SelecionarComboByText(string idElemento, string texto)
        {
            try
            {
                var campo = MoverTelaAteElementoVisivel(idElemento);
                SelectElement select = new SelectElement(MoverTelaAteElementoVisivel(idElemento));
                select.SelectByText(texto);
                return campo;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }

        /// <summary>
        /// Clicar Botao e retornar IWebElement
        /// </summary>
        public IWebElement ClicarBotao(string idElemento)
        {
            try
            {
                var campo = MoverTelaAteElementoVisivel(idElemento);
                campo.Click();
                return campo;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }

        public int RetornarQuantidadeRegistrosGrid(string idElemento)
        {
            try
            {
                var campo = MoverTelaAteElementoVisivel(idElemento);
                campo = campo.FindElement(By.TagName("tbody"));
                return campo.FindElements(By.TagName("tr")).Count;
            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }







        /// <summary>
        /// Retornar Valor de Elemento
        /// </summary>
        public string RetornaValorElemento(string Idelemento)
        {
            try
            {
                var elemento = MoverTelaAteElementoVisivel(Idelemento);
                var valor = elemento.Text.Trim();
                if (valor.Length > 0)
                {
                    return valor;
                }
                else
                {
                    return elemento.GetAttribute("Value").Trim();
                }


            }
            catch (Exception)
            {
                driver.Quit();
                throw;
            }
        }


        public IWebElement EsperarElementoSerVisivel(string idElemento, int timeout = 20)
        {
            try
            {
                var esperar = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return esperar.Until(ExpectedConditions.ElementIsVisible(By.Id(idElemento)));
            }
            catch (NoSuchElementException)
            {
                driver.Quit();
                throw;
            }
            
        }

        public IWebElement MoverTelaAteElementoVisivel(string idElemento, bool elementoAbaixo = true)
        {
            try
            {
                var elemento = EsperarElementoSerVisivel(idElemento);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", elemento);
                return elemento;
            }
            catch (Exception)
            {

                driver.Quit();
                throw;
            }
        }


    }
}
