using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@filename);
            string data = sr.ReadLine();

        }
    }
}
