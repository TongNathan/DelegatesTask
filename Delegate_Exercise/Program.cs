using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{

    internal class Delegate_Exercise
    {
        public delegate List<List<string>> parse(List<List<string>> data);
        public static void Main(string[] args)
        {
            string readFilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/data.csv";
            string writeFilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/processed_data.csv";

            DataParser dataParser = new DataParser();
            List<List<string>> handler(List<List<string>> data) =>
            dataParser.StripQuotes(data);
            CsvHandler csvHandler = new CsvHandler();
            csvHandler.ProcessCsv(readFilePath, writeFilePath, handler);

            Console.WriteLine("Done. ");
            Console.ReadLine();

        }

        public static List<List<string>> RemoveHash(List<List<string>> data)
        {
            List<List<string>> newdata = new List<List<string>>();
            foreach (List<string> row in data)
            {
                newdata.Add(new List<string>());
                foreach (string cell in row)
                {
                    newdata[data.IndexOf(row)].Add(cell.Trim('#'));
                }
            }

            data = newdata;
            return data;
    
        }

    }
}