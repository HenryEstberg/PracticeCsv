using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader r = new Reader("../../../../ProjectExample.csv");
            r.FileRead();
        }


    }
}
