using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using to_do_itv2.Models;

namespace to_do_itv2.Data
{
    public class ToDoService
    {
        private static ToDo[] toDoArray = new ToDo[0];
        public int toDoCount;

        public ToDo[] ToDoArray { get { return toDoArray; } }
        public int Size()
        {
            return toDoArray.Length;
        }
        public ToDo[] FindAll()
        {
            return toDoArray;
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
            Array.Resize(ref toDoArray, toDoArray.Length + 1);
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public ToDo NewToDo(string description)
        {
            ToDo t = new ToDo(TodoSequencer.NextToDoId(), description);
            Array.Resize(ref toDoArray, toDoArray.Length + 1);
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public ToDo NewToDo(int toDoId, string description, bool toDobool)
        {
            ToDo t = new ToDo(toDoId, description, toDobool);
            Array.Resize(ref toDoArray, toDoArray.Length + 1);
            toDoArray[toDoCount] = t;
            toDoCount++;
            return t;
        }
        public void Clear()
        {
            toDoArray = new ToDo[0];
            toDoCount = 0;
            TodoSequencer.Reset();
        }
        public ToDo[] FindByDoneStatus(bool done)
        {
            int counter = 0;
            ToDo[] boolStatusArray = new ToDo[0];
            foreach (ToDo toDo in toDoArray)
            {
                if (done == toDo.Done)
                {
                    Array.Resize<ToDo>(ref boolStatusArray, boolStatusArray.Length + 1);
                    boolStatusArray[counter++] = toDo;
                }    
            }
            return boolStatusArray;
        }
        public ToDo[] FindByAssignee(int personId)
        {
            int counter = 0;
            ToDo[] assigneeArray = new ToDo[0];
            foreach (ToDo toDo in toDoArray)
                {
                    if (personId == toDo.Assignee.PersonId)
                    {
                        Array.Resize<ToDo>(ref assigneeArray, assigneeArray.Length + 1);
                        assigneeArray[counter++] = toDo;
                    }
                }
            return assigneeArray;
        }
        public ToDo[] FindByAssignee(Person assignee)
        {
            int counter = 0;
            ToDo[] assigneeArray = new ToDo[0];
            foreach (ToDo toDo in toDoArray)
            {
                if (assignee == toDo.Assignee)
                {
                    Array.Resize<ToDo>(ref assigneeArray, assigneeArray.Length + 1);
                    assigneeArray[counter++] = toDo;
                }
            }
            return assigneeArray;
        }
        public ToDo[] FindUnassignedTodoItems()
        { 
            int counter = 0;
            ToDo[] unassignedItemArray = new ToDo[0];
            foreach (ToDo toDo in toDoArray)
            {
                if (toDo.Assignee == null)
                {
                    Array.Resize<ToDo>(ref unassignedItemArray, unassignedItemArray.Length + 1);
                    unassignedItemArray[counter++] = toDo;
                }
            }
            return unassignedItemArray;
        }
        public void RemoveItem(int x)
        {
            ToDo remove = FindById(x);
            for (int i = 0; i < toDoArray.Length; i++)
            {
                if (toDoArray[i] == remove)
                {
                    for (int offset = i + 1; offset < toDoArray.Length; offset++, i++)
                    {
                        toDoArray[i] = toDoArray[offset];
                    }
                    Array.Resize(ref toDoArray, toDoArray.Length - 1);
                    break;
                }
            }
        }
    }
}

