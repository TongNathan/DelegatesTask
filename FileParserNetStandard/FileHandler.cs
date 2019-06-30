using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard
{
    public class FileHandler
    {

        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(filePath)
                .ToList();
            return lines;
        }


        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            string[] people = new string[rows.Count];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int o = 0; o < rows[i].Count - 1; o++)
                {
                    people[i] += rows[i][o] + delimeter;
                }
                people[i] += rows[i].Last();
            }
            File.WriteAllLines(filePath, people);
        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter)
        {
            List<List<string>> ListData = new List<List<string>>();
            foreach (string dataline in data)
            {
                ListData.Add(dataline.Split(delimeter)
                    .ToList());
            }
            return new List<List<string>>(ListData);  //-- return result here
        }

        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            List<List<string>> ListData = new List<List<string>>();
            foreach (string dataline in data)
            {
                ListData.Add(dataline.Split(" , ".ToCharArray())
                    .ToList());
            }
            return new List<List<string>>(ListData);  //-- return result here
        }
    }
}