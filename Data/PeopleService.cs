using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Models;

namespace to_do_itv2.Data
{
    public class PeopleService
    {
        private static Person[] people = new Person[0];
        //private static List<Person> peopleList = new List<Person>();
        public int peopleCount;

        //public List<Person> PeopleList { get { return peopleList; } }
        public Person[] People { get { return people; } }
        public int Size()
        {
            return people.Length;
        }
        public Person[] FindAll()
        {
            return people;
        }
        public Person FindById(int personId)
        {
            return people[personId];
        }
        public Person NewPerson(string firstName, string lastName)
        {
            Person p = new Person(PersonSequencer.NextPersonId(), lastName, firstName);
            Array.Resize(ref people, people.Length+1);
            people[peopleCount] = p;
            //peopleList.Append<Person>(p);
            //people = peopleList.ToArray();
            peopleCount++;
            return p;
        }

        public void Clear()
        {
            //peopleList.Clear();
            people = new Person[0];
            peopleCount = 0;
        }
    }
}
