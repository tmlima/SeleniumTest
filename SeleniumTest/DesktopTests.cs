using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class DesktopTests
    {
        private string defaultFolder;
        private const string FakeContentFileName = "fake.txt";
        private const string FakeContent = "Fake content.";

        [TestInitialize]
        public void BeforeTest()
        {
            defaultFolder = @"C:\Projeto" + @"\" + DateTime.Now.Ticks + "_Desktop";
            CreateTxtFileWithContent( defaultFolder, FakeContentFileName, FakeContent );
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
                string logFileName = "Log_" + DateTime.Now.Ticks + "_Desktop.txt";
                problema2 = Process.Start( "problema2.exe", defaultFolder + " " + logFileName );
                problema2.WaitForExit();
                File.Delete( defaultFolder + @"\" + FakeContentFileName );
                Assert.IsTrue( TestSuccessfully( defaultFolder, logFileName ) );
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

        private bool TestSuccessfully(string logFilePath, string logFileName)
        {
            string log = File.ReadAllText( logFilePath + @"\" + logFileName );
            return log.Contains( "Test successfully" );
        }

        private void CreateTxtFileWithContent(string path, string fileName, string content)
        {
            StreamWriter stream = null;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory( path );
                }

                if (!File.Exists(path + @"\" + fileName))
                {
                    stream = File.CreateText( path + @"\" + fileName );
                    stream.Write( content );
                }
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
