using to_do_itv2.Data;
using to_do_itv2.Models;

namespace to_do_itv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PeopleService peopleService = new PeopleService();
            peopleService.NewPerson("Alex", "Vestelind");
            peopleService.NewPerson("Monika", "Vestelind");
            Console.WriteLine(peopleService.FindById(0));
            Console.WriteLine(peopleService.FindById(1));
            Console.WriteLine(peopleService.FindAll());
            Console.WriteLine(peopleService.Size());
        }
    }
}