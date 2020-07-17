using System;
using System.Collections.Generic;
using System.IO;

namespace CSVParser
{
    // Primitive CSV parser to avoid VB dependency that breaks VS2017 compilation
    public class SimpleCSVParser : IDisposable
    {
        private StreamReader _file;
        private string _nextline;

        public bool EndOfData
        {
            get { return _nextline == null;}
        }
        public SimpleCSVParser(string filename)
        {
            _file = new StreamReader(filename); // In real code this would be in a try/catch block to gracefully handle errors like file not found
            _nextline = _file.ReadLine();
        }

        public IList<string> ReadFields()
        {
            var fields = _nextline.Split(',');
            _nextline = _file.ReadLine(); // Advance the reader
            var result = new List<string>();
            var quoting = false;
            foreach (var field in fields)
            {
                var trimmed = field.Trim(); // Remove any leading or trailing whitespace
                if (trimmed.StartsWith('"'))
                {
                    if (trimmed.EndsWith('"'))
                    {
                        result.Add(trimmed.Substring(1,trimmed.Length-2)); // "foo" -> foo
                    }
                    else
                    {
                        quoting = true;
                        result.Add(trimmed.Substring(1)+","); // "foo -> foo,
                    }
                }
                else if (quoting)
                {
                    if (trimmed.EndsWith('"'))
                    {
                        result[result.Count-1] += field.Substring(0, field.IndexOf('"')); // foo" -> foo
                        quoting = false;
                    }
                    else
                    {
                        result[result.Count - 1] += field+","; 
                    }

                }
                else
                {
                    result.Add(trimmed);
                }
            }

            return result;
        }

        public void Dispose()
        {
            _file?.Close();
            _file?.Dispose();
        }
    }
}