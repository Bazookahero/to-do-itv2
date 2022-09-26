using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Models;

namespace to_do_itv2.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public static int NextPersonId(Person person)
        {
            personId = person.Id;
            return ++personId;
        }
        public static int Reset()
        {
            personId = 0;
            return personId;
        }
    }
}
