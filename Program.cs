using to_do_itv2.Data;
using to_do_itv2.Models;

namespace to_do_itv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(0, "Vestelind", "Alex");
            Person person2 = new Person(1, "Vestelind", "Max");

            Console.WriteLine(person1.Id + " " + person1.LastName + " " + person1.FirstName);
            Console.WriteLine(""+Person.PersonsCreated);
            Console.WriteLine("" + PersonSequencer.NextPersonId(person1));
            Console.WriteLine("" + PersonSequencer.Reset());
            Console.WriteLine("" + PersonSequencer.NextPersonId(person2));
        }
    }
}