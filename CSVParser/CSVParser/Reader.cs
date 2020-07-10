using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace CSVParser
{
    class Reader
    {
        private string filepath;
        private string animal;
        private double temp;
        private bool taboo;
        private string comment;
        Row rowObject;
        List<Row> rowList = new List<Row>();
        public Reader(string filepth)
        {
            this.filepath = filepth;
        }
        //This method runs through the csv file and 
        public void FileRead()
        {
            using (TextFieldParser fileReader = new TextFieldParser(filepath))
            {
                fileReader.SetDelimiters(new string[] {","});
                fileReader.HasFieldsEnclosedInQuotes = true;
                while (!fileReader.EndOfData)
                {
                    //reads a new line of the csv file
                    string[] lineData = fileReader.ReadFields();

                    //sets the paramaters of the row object and adds it to the list of rows
                    animal = Animal(lineData[0]);
                    temp = Cooking_temp(lineData[1]);
                    taboo = Taboo(lineData[2]);
                    comment = Comment(lineData[3]);
                    rowObject = new Row(animal, temp, taboo, comment);
                    rowList.Add(rowObject);

                    //spits out the contents of each cell individually into the console, pretty much ignores rows
                    /*foreach (var cell in lineData)
                    {
                        Console.WriteLine(cell);
                    }
                    */
                }
            }

            foreach (Row arr in rowList)
            {
                Console.WriteLine(arr.PrintRow());
            }

        }


        //--------------
        //helper methods
        //--------------
        private string Animal(string animal)
        {
            //I know it will always be a string, so there's no need for a conversion here
            return animal;
        }

        private double Cooking_temp(string temp)
        {
            //parseable is true if the computer can convert the string to a double

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

        private bool Taboo(string taboo)
        {
            bool parseable = Boolean.TryParse(taboo, out bool result);
            if (parseable == true)
            {
                return result;
            }
            //these if statements look for other ways the user could try to say "true" or "false"
            if (taboo == "yes" || taboo == "y")
            {
                return true;
            }

            if (taboo == "no" || taboo == "n")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        private string Comment(string comment)
        {
            return comment;
        }


    }
}
