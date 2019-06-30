using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard
{

    //public class Person { }  // temp class delete this when Person is referenced from dll

    public class PersonHandler
    {
        public List<Person> People = new List<Person>();

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            foreach (List<string> personRow in people.Skip(1))
            {
                Person person = new Person(int.Parse(personRow[0]), personRow[1], personRow[2], new DateTime(long.Parse(personRow[3])));
                People.Add(person);
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            DateTime oldie = People.Min(person => person.Dob);
            List<Person> getOldest =
                People
                .Where(person => person.Dob == oldie).ToList();

            return getOldest; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            /*string getID = People.Find(person => person.Id == id)
                .ToString();*/
            string getID = People.FirstOrDefault(person => person.Id == id)
            .ToString();
            return getID;  //-- return result here
        }

        public List<Person> GetOrderBySurname()
        {
            List<Person> surnameList = People.OrderBy(person => person.Surname).ToList();
            return surnameList;  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            int surNums = People.Count(person => person.Surname.StartsWith(searchTerm, !caseSensitive, CultureInfo.CurrentCulture));
            return surNums;  //-- return result here
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();
            IEnumerable<DateTime> unique = People.OrderBy(person => person.Dob)
                .Select(person => person.Dob)
                .Distinct();

            foreach (DateTime date in unique)
            {
                int counter = People.Count(person => person.Dob == date);
                result.Add(date + "\t" + counter);
            }
            return result;  //-- return result here
        }
    }
}