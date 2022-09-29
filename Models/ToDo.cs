using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Data;

namespace to_do_itv2.Models
{
    public class ToDo
    {
        private readonly int id;
        private string description;
        private bool done;
        private Person? assignee;

        public bool Done { get { return done; } set { done = value; } }
        public Person Assignee { get { return assignee; } set { assignee = value; } } 
        public string Description
        {
            get { return description; }
            set
            {
                if (description.Length < 2)
                {
                    Console.WriteLine("Description can't be shorter than 2 letters");
                }
             description = value;
            }
        }
        public int Id { get {return id; } }
        public ToDo(string description)
        {
            this.id = TodoSequencer.NextToDoId();
            this.description = description;
            Done = done;
        }
        public ToDo(int id, string description)
        {
            this.id = id;
            this.description = description;
            Done = done;
        }
        public ToDo(int id, string description, bool done)
        {
            this.id = id;
            this.description = description;
            Done = done;
        }
        public ToDo(int id, string description, bool done, Person assignee)
        {
            this.id = id;
            this.description = description;
            Done = done;
            Assignee = assignee;
        }
    }
}
