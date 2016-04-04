using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class DesktopTests
    {
        const string FakeContentFileName = "fake.txt";
        const string FakeContent = "Fake content.";

        [TestInitialize]
        public void BeforeTest()
        {
            CreateTxtFileWithContent( FakeContentFileName, FakeContent );
        }

        /// <summary>
        /// Pré requisitos: Criar um arquivo.txt com conteúdo fake.
        /// Condições: A biblioteca do Word não poderá ser utilizada.
        /// Abrir o Microsoft Word;
        /// Carregar o conteudo do arquivo texto previamente criado para dentro do Word;
        /// Bater um printscreen da tela do Word;
        /// Salvar o arquivo Word com TimeStamp, no mesmo folder do arquivo.txt;
        /// Deletar o arquivo.txt e manter o arquivo Word.
        /// </summary>
        [TestMethod]
        public void Problema2()
        {
            Process problema2 = null;
            try
            {
                problema2 = Process.Start( "problema2.exe" );
                problema2.WaitForExit();
                File.Delete( FakeContentFileName );
            }
            catch
            {
                throw;
            }
            finally
            {
                if (problema2 != null && !problema2.HasExited)
                    problema2.Kill();
            }
        }

        private void CreateTxtFileWithContent(string fileName, string content)
        {
            StreamWriter stream = null;
            try
            {
                stream = File.CreateText( fileName );
                stream.Write( content );
            }
            catch
            {
                throw;
            }
            finally
            {
                if ( stream != null )
                    stream.Close();
            }
        }
    }
}
