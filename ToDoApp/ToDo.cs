using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ToDoApp
{
    public class ToDo : IEnumerable<ToDoItem>, IEnumerable
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

        public void RemoveTask(int index)
        {
            items.RemoveAt(index);
        }

        public IEnumerator<ToDoItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}