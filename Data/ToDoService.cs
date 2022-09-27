using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Models;

namespace to_do_itv2.Data
{
    public class ToDoService
    {
        private static ToDo[] toDoArray = new ToDo[5];
        public int toDoCount;

        public ToDo[] ToDoArray { get { return toDoArray; } }
        public int Size()
        {
            return toDoArray.Length;
        }
        public ToDo FindAll()
        {
            for (int i = 0; i < toDoArray.Length; i++)
                return toDoArray[i];
            return null;
        }
        public ToDo FindById(int toDoId)
        {
            return toDoArray[toDoId];
        }
        public ToDo NewToDo(int id, string description)
        {
            ToDo t = new ToDo(TodoSequencer.NextToDoId(), description);
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public void Clear()
        {
            toDoArray = new ToDo[0];
            toDoCount = 0;
        }
    }
}

