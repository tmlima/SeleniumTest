using System;
using System.IO;

namespace SeleniumTest
{
    public class Log
    {
        private string fileName;

        public Log(string fileName)
        {
            this.fileName = "Log_" + DateTime.Now.Ticks + "_" + fileName + ".txt";
        }

        public void WriteMessage( string message )
        {
            string line = "[" + DateTime.Now.ToString( "yyyyMMdd_hhmmssfff" ) + "] " + message + Environment.NewLine;
            File.AppendAllText( this.fileName, line );
        }
    }
}
