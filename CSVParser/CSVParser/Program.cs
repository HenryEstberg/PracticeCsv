using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        private static string hasHeader;
        static void Main(string[] args)
        {
            // Right now the reader uses a set filepath relative to the .cs file that is set here in the code
            Console.WriteLine("Does the file that you have selected contain a header? (Y/N)");
            hasHeader = Console.ReadLine();
            Reader r = new Reader("../../../../ProjectExample.csv", hasHeader);
            r.FileRead();
        }


    }
}
