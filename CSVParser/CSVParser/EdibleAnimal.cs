using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSVParser
{
    class EdibleAnimal
    {
        public string animal;
        public double cookingTemp;
        public bool taboo;
        public string comment;
        public string error;
        public string errorSpot;
        public string notAvailable = "N/A";
        public bool hasError;


        public EdibleAnimal(string meat, double cookTemp, bool yn, string concerns)
        {
            this.animal = meat;
            this.cookingTemp = cookTemp;
            this.taboo = yn;
            this.comment = concerns;
            this.hasError = false;
        }

        //this overloaded method only gets activated when we pass in an error message on top of the other variables
        public EdibleAnimal(string meat, double cookTemp, bool yn, string concerns, string errorLocation, string errorMessage)
        {
            this.animal = meat;
            this.cookingTemp = cookTemp;
            this.taboo = yn;
            this.comment = concerns;
            this.error = errorMessage;
            this.errorSpot = errorLocation;
            this.hasError = true;
        }

        public string PrintRow()
        {
            if (errorSpot == "temp")
            {
                return (this.animal + ",  " + notAvailable + ",  " + this.taboo +
                        ",  " + this.comment + this.error);
            }
            else if (errorSpot == "taboo")
            {
                return (this.animal + ",  " + this.cookingTemp + ",  " + notAvailable +
                        ",  " + this.comment + this.error);
            }
            else if (errorSpot == "taboo and temp")
            {
                return (this.animal + ",  " + notAvailable + ",  " + notAvailable +
                        ",  " + this.comment + this.error);
            }

            return (this.animal + ",  " + this.cookingTemp + ",  " + this.taboo +
                    ",  " + this.comment + this.error);

        }

        //this method is very similar to the PrintRow method, but the syntax is different so it fits in a CSV
        //there are less spaces and more commas
        public string WriteCsvLine()
        {
            if (errorSpot == "temp")
            {
                return (this.animal + "," + notAvailable + "," + this.taboo +
                        "," + this.comment + "," + this.error);
            }
            else if (errorSpot == "taboo")
            {
                return (this.animal + "," + this.cookingTemp + "," + notAvailable +
                        "," + this.comment + "," + this.error);
            }
            else if (errorSpot == "taboo and temp")
            {
                return (this.animal + "," + notAvailable + "," + notAvailable +
                        "," + this.comment + "," + this.error);
            }

            return (this.animal + "," + this.cookingTemp + "," + this.taboo +
                    "," + this.comment + "," + this.error);
        }
    }
}
