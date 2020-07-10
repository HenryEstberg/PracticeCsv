using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Right now the reader uses a set filepath relative to the .cs file that is set here in the code
            Reader r = new Reader("../../../../ProjectExample.csv");
            r.FileRead();
        }


    }
}
