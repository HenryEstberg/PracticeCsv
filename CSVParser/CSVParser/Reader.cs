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
        public void FileRead()
        {
            using (TextFieldParser fileReader = new TextFieldParser(filepath))
            {
                fileReader.SetDelimiters(new string[] {","});
                fileReader.HasFieldsEnclosedInQuotes = true;
                while (!fileReader.EndOfData)
                {
                    string[] lineData = fileReader.ReadFields();
                    foreach (var cell in lineData)
                    {
                        Console.WriteLine(cell);
                    }
                }
            }

        }

        
    }
}
