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

        public bool ContainsSameTask
        {
            get
            {
                return !items.Any(item => item.Content == AddingTaskContent);
            }
        }

        public string AddingTaskContent { get; set; }

        public void AddTask()
        {
            if (string.IsNullOrWhiteSpace(AddingTaskContent)) throw new InvalidOperationException($"{nameof(AddingTaskContent)} is not allow empty.");

            items.Add(new ToDoItem(AddingTaskContent));

            AddingTaskContent = null;
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

        public bool CanClear
        {
            get
            {
                return items.Any();
            }
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}