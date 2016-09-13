using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;

namespace ToDoApp
{
    public class ToDo : IEnumerable<ToDoItem>, IEnumerable, INotifyPropertyChanged
    {
        private List<ToDoItem> items = new List<ToDoItem>();

        public IReadOnlyList<ToDoItem> Items
        {
            get
            {
                return items;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
        public bool CanAdd
        {
            get
            {
                return !string.IsNullOrWhiteSpace(addingTaskContent);
            }
        }

        public bool ContainsSameTask
        {
            get
            {
                return items.Any(item => item.Content == AddingTaskContent);
            }
        }

        private string addingTaskContent;

        public string AddingTaskContent
        {
            get
            {
                return addingTaskContent;
            }
            set
            {
                if (addingTaskContent != value)
                {
                    addingTaskContent = value;

                    OnPropertyChanged(nameof(AddingTaskContent));
                    OnPropertyChanged(nameof(CanAdd));
                }
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToDoItem.Done))
            {
                OnPropertyChanged(nameof(DoneCount));
            }
        }

        public void AddTask()
        {
            if (!CanAdd) return;

            var toDoItem = new ToDoItem(AddingTaskContent);

            toDoItem.PropertyChanged += ItemPropertyChanged;

            items.Add(toDoItem);

            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(CanClear));

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
            var toDoItem = items[index];

            toDoItem.PropertyChanged -= ItemPropertyChanged;

            items.Remove(toDoItem);

            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(DoneCount));
            OnPropertyChanged(nameof(CanClear));
        }

        public void Clear()
        {
            items.Clear();

            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(DoneCount));
            OnPropertyChanged(nameof(CanClear));
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
    }
}