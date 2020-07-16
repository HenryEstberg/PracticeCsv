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
        private bool tempParseError;   // stores if the cooking temp is parseable into a double
        private bool tempCommaError;   // stores if the cooking temp contains any commas
        private bool tabooParseError;  // stores if the taboo is parseable into a bool
        private string incorrectTemp;
        private string incorrectTaboo;

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
            if (File.Exists(this.filepath))
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
                        Console.Write("HD: ");
                        foreach (string str in lineData)
                        {
                            Console.Write(str + ",");
                            colNum++;
                        }

                        Console.WriteLine();

                    }

                    //prints the rest of the file and creates a collection of all of the data
                    while (!fileReader.EndOfData)
                    {
                        string[] lineData = fileReader.ReadFields();

                        //sets the parameters of the row object and adds it to the list of rows
                        animal = Animal(lineData[0]);
                        temp = Cooking_temp(lineData[1]);
                        taboo = Taboo(lineData[2]);
                        comment = Comment(lineData[3]);
                        //checks booleans indicating errors and adds appropriate error messages to the rows
                        if (tabooParseError && tempParseError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "taboo and temp" ,
                                "ERROR: taboo <" + incorrectTaboo + "> is not entered in yes / no format and cooking temp <" + incorrectTemp + "> is not entered as a numeral");
                        }
                        else if (tabooParseError && tempCommaError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "taboo and temp" ,
                                "ERROR: cooking temp <" + incorrectTemp + "> contains commas and taboo <" + incorrectTaboo + "> is not entered in yes / no format");
                        }
                        else if (tempCommaError && tempParseError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "temp",
                                "ERROR: cooking temp <"+ incorrectTemp + "> contains commas and is not entered as a numeral");
                        }
                        else if (tempCommaError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "temp", " ERROR: cooking temp <" + incorrectTemp +"> contains commas");
                        }
                        else if (tempParseError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "temp" ,
                                "ERROR: cooking temp <"+ incorrectTemp + "> is not entered as a numeral");
                        }
                        else if (tabooParseError)
                        {
                            rowObject = new Row(animal, temp, taboo, comment, "taboo",
                                "ERROR: taboo <"+ incorrectTaboo + "> is not entered in yes / no format");
                        }
                        else
                        {
                            rowObject = new Row(animal, temp, taboo, comment);
                        }

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
                    Console.WriteLine(arr.WriteCsvLine());

                    rowNum++;
                }
            }

        }


        //--------------
        //helper methods
        //--------------
        private string Animal(string animal)
        {
            //I know it will always be a string, so there's no need for a conversion here
            
            //adds quotation marks if the string contains commas
            if (animal.Contains(","))
            {
                return "\"" + animal + "\"";
            }
            return animal;
        }

        private double Cooking_temp(string temp)
        {
           //parseable is true if the computer can convert the string to a double

            bool parseable = Double.TryParse(temp, out double result);

            if (parseable)
            {
                tempParseError = false;
                if (temp.Contains(","))
                {
                    tempCommaError = true;
                    incorrectTemp = temp;
                    return 0;
                }
                return result;
            }
            else
            {
               tempParseError = true;
               incorrectTemp = temp;
                //We will return a default value so that the code runs
                return 0;
            }
        }

        private bool Taboo(string taboo)
        {
            bool parseable = Boolean.TryParse(taboo, out bool result);
            if (parseable)
            {
                return result;
            }
            //these if statements look for other ways the user could try to say "true" or "false"
            if (taboo == "yes" || taboo == "y")
            {
                tabooParseError = false;
                return true;
            }
            else if (taboo == "no" || taboo == "n")
            {
                tabooParseError = false;
                return false;
            }
            else
            {
                tabooParseError = true;
                incorrectTaboo = taboo;
                return false;
            }
        }

        private string Comment(string comment)
        {
            if (comment.Contains(","))
            {
                return "\"" + comment + "\"";
            }
            return comment;
        }


    }
}
