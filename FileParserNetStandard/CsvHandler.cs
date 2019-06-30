using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;
using System.IO;
using System.Linq;

namespace Delegate_Exercise
{
   public class CsvHandler

   {
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {
            FileHandler handler = new FileHandler();
            List<string> items = handler.ReadFile(readFile);

            List<List<string>> rows = handler.ParseCsv(items);
            List<List<string>> newrows = dataHandler(rows);
            //lines need to become rows (List<string> into <List<List<string>>>
            handler.WriteFile(writeFile, ',', newrows);
        }

    }
}