using System;
using System.Linq;
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

        public int DoneCount
        {
            get
            {
                return items.Count(item => item.Done);
            }
        }

        public ToDo()
        {
        }

        public void AddTask(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentException("not allow empty or whitespace.", nameof(content));

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