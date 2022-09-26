using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Models;

namespace to_do_itv2.Data
{
    public class TodoSequencer
    {
        private static int toDoId;

        public static int NextToDoId(ToDo toDo)
        {
            toDoId = toDo.Id;
            return ++toDoId;
        }
        public static int Reset()
        {
            toDoId = 0;
            return toDoId;
        }
    }
}
