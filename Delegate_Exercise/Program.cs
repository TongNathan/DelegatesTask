using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;
using ObjectLibrary;


public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{


    internal class Delegate_Exercise
    {

        public static List<List<string>> StripHash(List<List<string>> data)
        {
            //string newtext = ""; ;
            List<List<string>> list = new List<List<string>>();
            List<string> links = new List<string>();
            //foreach (List<string> items in data)
            for (int i = 0; i < data.Count; i++)
            {
                List<string> line = new List<string>();
                for (int o = 0; o < data[0].Count; o++)
                {
                    string text = data[i][o];
                    while (text.Contains("#"))
                    {
                        int index = text.IndexOf('#');
                        text = text.Remove(index, 1);
                    }
                    line.Add(text);
                }
                list.Add(line);
            }
            return DataParser.PutDataBack(data, list);
        }
        public static void Main(string[] args)
        {
            DataParser data = new DataParser();
            CsvHandler handler = new CsvHandler();
            FileHandler filehand = new FileHandler();
            string readPath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/data.csv";
            string writePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/processed_data.csv";
            Func<List<List<string>>, List<List<string>>> Trimmer = new Func<List<List<string>>, List<List<string>>>(data.StripQuotes);
            Trimmer += data.StripWhiteSpace;
            Trimmer += StripHash;
            handler.ProcessCsv(readPath, writePath, Trimmer);

        }



    }
}