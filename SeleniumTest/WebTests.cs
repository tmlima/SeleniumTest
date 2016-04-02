using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class WebTests
    {
        [TestMethod]
        public void Problema1IE()
        {
            this.Problema1( new InternetExplorerDriver() );
        }

        [TestMethod]
        public void Problema1Chrome()
        {
            this.Problema1( new ChromeDriver() );
        }

        [TestMethod]
        public void Problema1Firefox()
        {
            this.Problema1( new FirefoxDriver() );
        }

        /// <summary>
        /// Entrar no site www.dbserver.com.br;
        /// Acessar a área de Contato, do Menu superior da página;
        /// Preencher o formulário de Fale Conosco;
        /// Não enviar o formulário, apenas bater um printscreen com os dados preenchidos;
        /// Gerar evidencias de teste – log de execução( txt ) e printscreen.
        /// </summary>
        private void Problema1( RemoteWebDriver driver )
        {
            const string InitialUrl = "http://www.dbserver.com.br";

            try
            {
                driver.Navigate().GoToUrl( InitialUrl );
                driver.FindElement( By.LinkText( "CONTATO" ) ).Click();
                FillFaleConoscoFields( driver );
                TakeScreenshot( driver );
            }
            catch
            {
                throw;
            }
            finally
            {
                if ( driver != null )
                    driver.Quit();
            }
        }

        private void FillFaleConoscoFields( RemoteWebDriver driver )
        {
            driver.FindElement( By.Name( "name" ) ).SendKeys( "A" );
            driver.FindElement( By.Name( "email" ) ).SendKeys( "a@a.com" );
            driver.FindElement( By.Name( "textAssunto" ) ).SendKeys( "Um assunto" );
            new SelectElement( driver.FindElement( By.Id( "setor" ) ) ).SelectByIndex(1);
            driver.FindElement( By.Name( "message" ) ).SendKeys( "Minha mensagem" );
        }

        private void TakeScreenshot(RemoteWebDriver driver)
        {
            const string ScreenshotsDirectory = "Screenshots";
            Screenshot screenshots = ( (ITakesScreenshot)driver ).GetScreenshot();
            if ( !Directory.Exists( ScreenshotsDirectory ) )
            {
                Directory.CreateDirectory( ScreenshotsDirectory );
            }
            screenshots.SaveAsFile( 
                ScreenshotsDirectory + @"\" + driver.GetType().Name + "_" + DateTime.Now.Ticks + ".png", 
                System.Drawing.Imaging.ImageFormat.Png );
        }
    }
}
