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
            ParserTest("../../../../ProjectExample.csv", "fish,  120.24,  False,  rabbit,  275,  False,  clown,  -360,  True,  does this taste funny to you?horse,  N/A,  True,  there's an error hereERROR: cooking temp <snotwaffle> is not entered as a numeralbird,  N/A,  False,  uh oh, rogue commas ERROR: cooking temp <5,4,3> contains commas123,  N/A,  N/A,  what a messERROR: taboo <b flat> is not entered in yes / no format and cooking temp <hi mom> is not entered as a numeral");
            ParserTest("../../../../ProjectExample2.csv", "fish,  N/A,  False,  ERROR: cooking temp <> is not entered as a numeralrabbit,  N/A,  False,  ERROR: cooking temp <> is not entered as a numeralclown,  N/A,  True,  does this taste funny to you?ERROR: cooking temp <> is not entered as a numeralhorse,  N/A,  True,  there's an error hereERROR: cooking temp <> is not entered as a numeralbird,  N/A,  False,  chirpERROR: cooking temp <> is not entered as a numeral123,  N/A,  N/A,  what a messERROR: taboo <b flat> is not entered in yes / no format and cooking temp <> is not entered as a numeral");
            ParserTest("../../../../ProjectExample3.csv", "fish,  120.24,  False,  rabbit,  275,  False,  -360,  N/A,  N/A,  does this taste funny to you?ERROR: taboo <clown> is not entered in yes / no format and cooking temp <yes> is not entered as a numeralhorse,  N/A,  N/A,  there's an error hereERROR: taboo <clown> is not entered in yes / no format and cooking temp <snotwaffle> is not entered as a numeralbird,  N/A,  False,  uh oh, rogue commas ERROR: cooking temp <5,4,3> contains commas123,  N/A,  N/A,  what a messERROR: taboo <b flat> is not entered in yes / no format and cooking temp <hi mom> is not entered as a numeral");
            ParserTest("../../../../ProjectExample4.csv", "fish,  120.24,  False,  rabbit,  275,  False,  does this taste funny to you?,  -360,  True,  clownhorse,  N/A,  True,  there's an error hereERROR: cooking temp <snotwaffle> is not entered as a numeralbird,  N/A,  False,  uh oh, rogue commas ERROR: cooking temp <5,4,3> contains commas123,  N/A,  N/A,  what a messERROR: taboo <b flat> is not entered in yes / no format and cooking temp <hi mom> is not entered as a numeral");


        }

        //Commented out because there's a new method below that works for all files
       /* public static void FunctionTest()
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
        } */

        public static void ParserTest(string filepath, string desiredOutput)
        {
            string output = "";
            Reader f = new Reader(filepath);
            var testMenu = f.FileRead();
            foreach (var animal in testMenu)
            {
                output = output + animal.PrintRow();
            }

            if (!output.Equals(desiredOutput))
            {
                Console.WriteLine("Output for file " + filepath + " does not match expected output");
            }
            else
            {
                Console.WriteLine("Output for " + filepath + " matches expected output");
            }
        }
        
    }
}
