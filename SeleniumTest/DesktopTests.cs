using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class DesktopTests
    {
        const string FakeContentFileName = "fake.txt";
        const string FakeContent = "Fake content.";

        [TestInitialize]
        public void MyTestInitialize()
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
            File.Delete( FakeContentFileName );
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
