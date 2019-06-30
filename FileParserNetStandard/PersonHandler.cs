using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;
using Delegate_Exercise;


namespace FileParserNetStandard
{

    //public class Person { }  // temp class delete this when Person is referenced from dll

    public class PersonHandler
    {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            // List<string> data = new List<string>();       

            foreach (List<string> data in people.Skip(1))
            {
                Person person = new Person(int.Parse(data[0]), data[1], data[2], DateTime.Parse(data[3]));
                People.Add(person);
            }


        }

        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {

            //return new List<Person>(); 
            return People.GroupBy(per => per.Dob).OrderBy(g => g.Key).First().ToList();
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {

            //return "result"; 
            return People.Find(x => x.Id == id).ToString();
        }

        public List<Person> GetOrderBySurname()
        {
            //return new List<Person>();
            return People.OrderBy(name => name.Surname).ToList();
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {

            //return 0;  
            return People.Where(p => p.Surname.StartsWith(searchTerm, caseSensitive, null)).Count();
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            //return result; 
            return People.GroupBy(per => per.Dob).OrderBy(g => g.Key).Select(g => $"{g.Key.ToString()} \t {g.Count()}").ToList();

        }
    }
}