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
        private static int personId = 0;

        public static int PersonId { get { return personId; } set { personId = value; } }
        public static int NextPersonId()
        {
            return personId++;
        }
        public static int Reset()
        {
            personId = 0;
            return personId;
        }
    }
}
