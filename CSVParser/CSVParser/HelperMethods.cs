using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSVParser
{
    class HelperMethods
    {
   

        static string Animal(string animal)
        {
          //I know it will always be a string, so there's no need for a conversion here
          return animal;
        }

        static double Cooking_temp(string temp)
        {
           // parseable is true if the computer can convert the string to a double
            
           bool parseable = Double.TryParse(temp, out double result);

            if (parseable == true)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        static bool Taboo(string taboo)
        {
            bool parseable = Boolean.TryParse(taboo, out bool result);
            if (parseable == true)
            {
                return result;
            }
            else
            {
                return false;
            }
        }

        static string Comment(string comment)
        {
            return comment;
        }
    }
}
