using System.ComponentModel;

namespace ToDoApp
{
    public class ToDoItem : INotifyPropertyChanged
    {
        private readonly string content;

        public ToDoItem(string content)
        {
            this.content = content;
        }

        public string Content
        {
            get
            {
                return content;
            }
        }

        private bool done;

        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                if (done != value)
                {
                    done = value;

                    OnPropertyChanged(nameof(Done));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}