using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        private List<ToDoItem> items = new List<ToDoItem>();


        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public ToDo()
        {
        }

        public void AddTask(string content)
        {
            items.Add(new ToDoItem(content));
        }

        public ToDoItem this[int index]
        {
            get
            {
                return items[index];
            }
        }
    }
}