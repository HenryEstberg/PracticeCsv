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
        //basic variables
        private string filepath;       //stores the filepath from the executable to the csv file to be parsed
        private string hasHeader;      //the user input (should be "Y" or "N") from when they were asked if their file contains a header
        private string animal;         //stores the animal name for the current line of the file being parsed
        private double temp;           //stores the cooking temperature for the current line of the file being parsed
        private bool taboo;            //stores if the meat is taboo for the current line of the file being parsed
        private string comment;        //stores the comment for the current line of the file being parsed
        private int colNum;            //stores which column the current cell being printed belongs to, for readability
        private int rowNum;            //stores the number of the current row, for readability

        Row rowObject;                 //currently the rowObject itself is setup to only allow a set number of specific entries per row in the csv file
        List<Row> rowList = new List<Row>();

        public Reader(string filepth)
        {
            this.filepath = filepth;
        }
        public Reader(string filepth, string header)
        {
            this.filepath = filepth;
            this.hasHeader = header;
        }
        //This method runs through the csv file and displays its contents
        public void FileRead()
        {
            using (TextFieldParser fileReader = new TextFieldParser(filepath))
            {
                fileReader.SetDelimiters(new string[] {","});
                fileReader.HasFieldsEnclosedInQuotes = true;

                //prints the appropriate header if the file contains one
                if (hasHeader.Equals("Y"))
                {
                    //reads a new line of the csv file
                    string[] lineData = fileReader.ReadFields();
                    colNum = 0;
                    foreach (string str in lineData)
                    {
                        Console.Write("(" + colNum + ") " + str + " || ");
                        colNum++;
                    }
                    Console.WriteLine();

                }

                //prints the rest of the file and creates a collection of all of the data
                while (!fileReader.EndOfData)
                {
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

            rowNum = 0;
            foreach (Row arr in rowList)
            {
                Console.Write("R" + rowNum + ": ");
                Console.WriteLine(arr.PrintRow());
                rowNum++;
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
