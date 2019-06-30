using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;


public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    internal class Delegate_Exercise
    {

        public static void Main(string[] args)
        {
            string readfilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/data.csv";
            string writefilePath = @"C:/Users/Nathan/source/repos/DelegatesTask/Files/processed_data.csv";
            DataParser dataParser = new DataParser();

            List<List<string>> handler(List<List<string>> data) =>

            dataParser.StripQuotes(data);

            CsvHandler csvHandler = new CsvHandler();

            csvHandler.ProcessCsv(readfilePath, writefilePath, handler);

            Console.WriteLine("Certified BRUH Moment ");
            Console.ReadLine();



        }

        public static List<List<string>> StripHash(List<List<string>> data)
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