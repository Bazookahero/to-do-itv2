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

            Console.WriteLine(person1.PersonId + " " + person1.LastName + " " + person1.FirstName);
            Console.WriteLine(""+Person.PeopleCreated);
            /*Console.WriteLine("" + PersonSequencer.NextPersonId(person1));
            Console.WriteLine("" + PersonSequencer.Reset());
            Console.WriteLine("" + PersonSequencer.NextPersonId(person2));*/
            Console.WriteLine(toDo1.Id + " " + toDo1.Description);
            

            PeopleService peopleService = new PeopleService();
            peopleService.NewPerson("Vestelind", "Monika");
            //Console.WriteLine(person3.Id + " " + person3.FirstName + " " +person3.LastName);
            
            Console.WriteLine(peopleService.FindById(0));
            Console.WriteLine(peopleService.Size());
            Console.WriteLine(peopleService.FindAll());
            Console.WriteLine(Person.PeopleCreated);
            peopleService.Clear();
            foreach (Person person in peopleService.People)
            Console.WriteLine(" "+person);
            
            
            //Console.WriteLine(PeopleService.Size(peopleService));
            
        }
    }
}