using to_do_itv2.Models;

namespace to_do_itv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(0, "Vestelind", "Alex");

            Console.WriteLine(person1.Id + " " + person1.LastName + " " + person1.FirstName);
            Console.WriteLine(person1.PersonsCreated);
        }
    }
}