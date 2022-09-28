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
        //private Person[] people2 = new Person[people.Length + 1];
        public int peopleCount;

        public Person[] People { get { return people; } 
            /*set
            {
                for (int i = 0; i < people.Length; i++)
                {
                    people[i] = people2[i];
                }
            }*/
        }
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
            people = new Person[peopleCount+1];
            people[peopleCount] = p;
            peopleCount++;
            //people2.Append(p);
            return p;
        }

        public void Clear()
        {
            people = new Person[0];
            peopleCount = 0;
        }
    }
}
