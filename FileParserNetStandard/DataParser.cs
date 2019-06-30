using System.Collections.Generic;
using System.Linq;
using System;

namespace FileParserNetStandard
{
    public class DataParser
    {
        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            List<List<string>> ListData = new List<List<string>>();
            char[] TrimChars = { ' ' };
            foreach (List<string> dataline in data)
            {
                ListData.Add(new List<string>());
                foreach (string datacell in dataline)
                {
                    ListData[data.IndexOf(dataline)].Add(datacell.Trim(TrimChars));
                }
            }
            data = ListData;
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            List<List<string>> ListData = new List<List<string>>();
            char[] TrimChars = { '"' };
            foreach (List<string> dataline in data)
            {
                ListData.Add(new List<string>());
                foreach (string datacell in dataline)
                {
                    ListData[data.IndexOf(dataline)].Add(datacell.Trim(TrimChars));
                }
            }
            data = ListData;
            return data;
        }
    }
}