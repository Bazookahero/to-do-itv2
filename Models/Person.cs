using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Data;

namespace to_do_itv2.Models
{
    public class Person
    {
        private static int idCounter = 0;
        private readonly int id;
        private string firstName;
        private string lastName;
        
        public string FullName { get { return FirstName + " "+ LastName; } }
        public static int PeopleCreated { get { return idCounter; } }
        public int PersonId { get { return id; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("First name must contain at least 2 letters");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("Last name must contain at least 2 letters");
                }
                lastName = value;
            }
        }
        public Person(int id, string LastName, string FirstName)
        {
            idCounter++;
            this.id = id;
            firstName = FirstName;
            lastName = LastName;
        }
        public Person(string LastName, string FirstName)
        {
            idCounter++;
            this.id = PersonSequencer.NextPersonId();
            firstName = FirstName;
            lastName = LastName;
        }
        public override string ToString()
        {
            return
                "" + PersonId + " " + LastName + " " + FirstName; 
        }
    }
}
