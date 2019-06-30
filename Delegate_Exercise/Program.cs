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
            FileHandler fileHandler = new FileHandler();
            DataParser dataParser = new DataParser();
            CsvHandler csvHandler = new CsvHandler();

            string ReadFilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/data.csv";
            string WriteFilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/processed_data.csv";


        //csvHandler.ProcessCsv(ReadFilePath, WriteFilePath, data => trim(data));


        Func<List<List<string>>, List<List<string>>> trim = new Func<List<List<string>>, List<List<string>>>(dataParser.StripQuotes);
            trim = trim + dataParser.StripWhiteSpace;
            trim = trim + RemoveHash;
            csvHandler.ProcessCsv(ReadFilePath, WriteFilePath, trim);
            Console.ReadKey();

        }

        public static List<List<string>> RemoveHash(List<List<string>> data)
        {
            return data.Select(r => r.Select(y => y.Trim('#')).ToList()).ToList();
        }





    }
}