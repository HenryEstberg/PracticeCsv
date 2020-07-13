using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSVParser
{
    class HelperMethods
    {
        

        static bool CookingTempError(string temp)
        {
            //If there's no problem, this method returns false. "true" means there is an error
            bool parseable = Double.TryParse(temp, out double result);
            if (parseable == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool TabooError(string taboo)
        {
            //If there's no problem, this method returns false. "true" means there is an error
            bool parseable = Boolean.TryParse(taboo, out bool result);
            if (parseable == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
