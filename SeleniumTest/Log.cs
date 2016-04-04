using System;
using System.IO;

namespace SeleniumTest
{
    public class Log
    {
        private string fileName;

        public Log(string path)
        {
            if ( !Directory.Exists( path ) )
            {
                Directory.CreateDirectory( path );
            }
            this.fileName = path + @"\Log.txt";
        }

        public void WriteMessage( string message )
        {
            string line = "[" + DateTime.Now.ToString( "yyyyMMdd_hhmmssfff" ) + "] " + message + Environment.NewLine;
            File.AppendAllText( this.fileName, line );
        }
    }
}
