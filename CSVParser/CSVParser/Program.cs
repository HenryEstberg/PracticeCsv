using System;
using System.IO;
using System.Linq;

namespace CSVParser
{
    class Program
    {
        private static string customFilePath;
        
        static void Main(string[] args)
        {
            //Console.WriteLine("Does your file contain a header? (Y/N)");
            //hasHeader = Console.ReadLine();
            Console.WriteLine("Do you want to enter a custom file path? (Y/N)");

            //need to check validity of filepath somewhere

            customFilePath = "../../../../ProjectExample.csv";
            if (Console.ReadLine().Equals("Y"))
            {
                Console.WriteLine("Enter exact filepath from the executable to the desired file:");
                customFilePath = Console.ReadLine();
            }

            Reader r = new Reader(customFilePath);

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

            //Tests that the parser is doing what its supposed to do
            FunctionTest();



        }

        //Tests that the parser is doing what its supposed to do. Should be updated if the parser desired output is changed
        public static void FunctionTest()
        {
            string output = "";
            string file1DesiredOutput = "fish,  120.24,  False,  rabbit,  275,  False,  clown,  -360,  True,  does this taste funny to you?horse,  N/A,  True,  there's an error hereERROR: cooking temp <snotwaffle> is not entered as a numeralbird,  N/A,  False,  uh oh, rogue commas ERROR: cooking temp <5,4,3> contains commas123,  N/A,  N/A,  what a messERROR: taboo <b flat> is not entered in yes / no format and cooking temp <hi mom> is not entered as a numeral";
            Reader f = new Reader("../../../../ProjectExample.csv");
            var testMenu = f.FileRead();
            foreach (var animal in testMenu)
            {
                output = output + (animal.PrintRow());
            }

            if (!output.Equals(file1DesiredOutput))
            {
                Console.WriteLine("Output does not match expected output");
            }
            else
            {
                Console.WriteLine("Output matches expected output");
            }
            

            //Console.WriteLine(output);
        }


    }
}
