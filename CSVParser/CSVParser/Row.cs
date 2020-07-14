using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSVParser
{
    class Row
    {
        public string animal;
        public double cookingTemp;
        public bool taboo;
        public string comment;
        public string error;


        public Row(string meat, double cookTemp, bool yn, string concerns)
        {
            this.animal = meat;
            this.cookingTemp = cookTemp;
            this.taboo = yn;
            this.comment = concerns;
        }
        public Row(string meat, double cookTemp, bool yn, string concerns, string errorMessage)
        {
            this.animal = meat;
            this.cookingTemp = cookTemp;
            this.taboo = yn;
            this.comment = concerns;
            this.error = errorMessage;
        }
        public string PrintRow()
        {
            return ("(0): " + this.animal + ", (1): " + this.cookingTemp + ", (2): " + this.taboo +
                    ", (3): " + this.comment + this.error);

        }
    }
}
