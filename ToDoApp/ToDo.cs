using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        private List<string> tasks = new List<string>();

        public int Count
        {
            get
            {
                return tasks.Count;
            }
        }

        public ToDo()
        {
        }

        public void AddTask(string taskText)
        {
            tasks.Add(taskText);
        }
    }
}