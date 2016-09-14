using ToDoModel;

namespace ToDoFormApp
{
    public class Presenter
    {
        private ToDo model;
        private IMainView view;

        public Presenter(IMainView view, ToDo model)
        {
            this.view = view;
            this.model = model;
        }
    }
}