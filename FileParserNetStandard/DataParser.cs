using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard
{
    public class DataParser
    {
        public static List<List<string>> PutDataBack(List<List<string>> oldData, List<List<string>> newData)
        {
            for (var i = 0; i < oldData.Count; i++) oldData[i] = newData[i];
            return oldData;
        }

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            List<List<string>> list = new List<List<string>>();
            //foreach (List<string> items in data)
            for (int i = 0; i < data.Count; i++)
            {
                List<string> line = new List<string>();
                for (int o = 0; o < data[0].Count; o++)
                {
                    string item = data[i][o];
                    //while (item.Contains(" "))
                    //{
                    item = item.Trim();
                    //}


                    line.Add(item);
                }
                list.Add(line);
            }
            return PutDataBack(data, list);
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < data.Count; i++)
            {
                List<string> line = new List<string>();
                for (int o = 0; o < data[0].Count; o++)
                {
                    string item = data[i][o];
                    item = item.Trim('"');

                    line.Add(item);
                }
                list.Add(line);
            }
            return PutDataBack(data, list);

        }

    }
}