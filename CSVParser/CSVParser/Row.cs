using System;
using System.Collections.Generic;
using System.Text;

namespace CSVParser
{
    class Row
    {
        public string animal;
        public double cookingTemp;
        public bool taboo;
        public string comment;

        public Row(string meat, double cookTemp, bool yn, string concerns)
        {
            this.animal = meat;
            this.cookingTemp = cookTemp;
            this.taboo = yn;
            this.comment = concerns;
        }

        public string PrintRow()
        {
            return ("(0): " + this.animal + ", (1): " + this.cookingTemp + ", (2): " + this.taboo +
                    ", (3): " + this.comment);
        }
    }
}
