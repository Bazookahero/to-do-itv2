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
        private static ToDo[] toDoArray = new ToDo[10];
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
        public ToDo NewToDo(string description, bool toDobool, Person assignee)
        {
            ToDo t = new ToDo(TodoSequencer.NextToDoId(), description, toDobool, assignee);
            Array.Resize(ref toDoArray, toDoArray.Length + 1);
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public ToDo NewToDo(string description, bool toDobool)
        {
            ToDo t = new ToDo(TodoSequencer.NextToDoId(), description, toDobool);
            toDoArray = new ToDo[toDoCount+1];
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public void Clear()
        {
            toDoArray = new ToDo[0];
            toDoCount = 0;
        }
        public ToDo[] FindByDoneStatus(bool done)
        {
            ToDo[] boolStatusArray = new ToDo[toDoArray.Length];
            foreach (ToDo toDo in toDoArray)
            {
                if(done == toDo.Done)
                {
                    boolStatusArray.Append(toDo);
                }
            }
            return boolStatusArray;
        }
        public ToDo[] FindByAssignee(int personId)
        {
            ToDo[] assigneeArray = new ToDo[toDoArray.Length];
            foreach (ToDo toDo in toDoArray)
            {
                if (personId == toDo.Id)
                {
                    assigneeArray.Append(toDo);
                }
            }
            return assigneeArray;
        }
        public ToDo[] FindByAssignee(Person assignee)
        {
            ToDo[] assigneeArray = new ToDo[toDoArray.Length];
            foreach (ToDo toDo in toDoArray)
            {
                if (assignee == toDo.Assignee)
                {
                    assigneeArray.Append(toDo);
                }
            }
            return assigneeArray;
        }
        public ToDo[] FindUnassignedTodoItems()
        {
            ToDo[] unassignedItemArray = new ToDo[toDoArray.Length];
            foreach (ToDo toDo in toDoArray)
            {
                if (toDo.Assignee == null)
                {
                    unassignedItemArray.Append(toDo);
                }
            }
            return unassignedItemArray;
        }
    }
}

