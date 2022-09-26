using to_do_itv2.Data;
using to_do_itv2.Models;

namespace to_do_itv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDo toDo1 = new ToDo(1, "chores");
            ToDo toDo2 = new ToDo(0, "code");
            Person person1 = new Person(0, "Vestelind", "Alex");
            Person person2 = new Person(1, "Vestelind", "Max");

            Console.WriteLine(person1.Id + " " + person1.LastName + " " + person1.FirstName);
            Console.WriteLine(""+Person.PersonsCreated);
            Console.WriteLine("" + PersonSequencer.NextPersonId(person1));
            Console.WriteLine("" + PersonSequencer.Reset());
            Console.WriteLine("" + PersonSequencer.NextPersonId(person2));
            Console.WriteLine(toDo1.Id + " " + toDo1.Description);
            Console.WriteLine(TodoSequencer.NextToDoId(toDo2));
        }
    }
}