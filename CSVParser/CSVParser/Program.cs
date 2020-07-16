using System;
using System.IO;

namespace CSVParser
{
    class Program
    {
        private static string hasHeader;
        private static string customFilePath;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Does your file contain a header? (Y/N)");
            hasHeader = Console.ReadLine();
            Console.WriteLine("Do you want to enter a custom file path? (Y/N)");

            //need to check validity of filepath somewhere

            if (Console.ReadLine().Equals("Y"))
            {
                Console.WriteLine("Enter exact filepath from the executable to the desired file:");
                customFilePath = Console.ReadLine();
                Reader r = new Reader(customFilePath, hasHeader);
                var todaysMenu = r.FileRead();
            }
            else
            {
                Reader r = new Reader("../../../../ProjectExample2.csv", hasHeader);
                var todaysMenu = r.FileRead();
            }
            
        }


    }
}
