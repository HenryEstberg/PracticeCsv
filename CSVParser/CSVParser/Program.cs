using System;
using System.IO;
using System.Linq;

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
                
                Console.WriteLine(string.Format("today we have {0}", string.Join(", ", todaysMenu.Select(item => item.animal))));

                if (todaysMenu.Any(a => a.hasError))
                {
                    Console.Write("But...");
                    foreach (var animal in todaysMenu.Where(a => a.hasError))
                    {
                        Console.WriteLine("I don't know what's going on with row #{0}: {1}", todaysMenu.IndexOf(animal), animal.error);

                    }
                }
                foreach (var animal in todaysMenu.Where(a => a.taboo))
                {
                    Console.WriteLine(string.Format(@"I will not eat {0}, it is forbidden", animal.animal));
                }
            }

           
            
        }


    }
}
