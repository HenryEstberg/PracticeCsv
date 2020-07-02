using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../../ProjectExample.csv");
            string data = sr.ReadLine();
            while (data != null)
            {
                string[] commaSeperated = data.Split(',');
                Console.WriteLine(data);
                data = sr.ReadLine();
            }

        }
    }
}
