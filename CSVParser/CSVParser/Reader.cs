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
        public string filepath;
        public Reader(string filepth)
        {
            this.filepath = filepth;
        }
        //This method runs through the csv file and separates the contents into cell strings row by row
        public void FileRead()
        {
            using (TextFieldParser fileReader = new TextFieldParser(filepath))
            {
                fileReader.SetDelimiters(new string[] {","});
                fileReader.HasFieldsEnclosedInQuotes = true;
                while (!fileReader.EndOfData)
                {
                    string[] lineData = fileReader.ReadFields();

                    //spits out the contents of each cell individually into the console
                    foreach (var cell in lineData)
                    {
                        Console.WriteLine(cell);
                    }
                }
            }

        }

        
    }
}
