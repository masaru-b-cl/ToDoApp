namespace ToDoApp
{
    public class ToDoItem
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
    }
}