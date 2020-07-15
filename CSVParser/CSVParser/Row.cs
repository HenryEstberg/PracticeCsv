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
        
        //this overloaded method only gets activated when we pass in an error message on top of the other variables
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
            return (this.animal + ",  " + this.cookingTemp + ",  " + this.taboo +
                    ",  " + this.comment + this.error);

        }
    }
}
