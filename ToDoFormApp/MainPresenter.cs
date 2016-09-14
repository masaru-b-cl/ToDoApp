using System.Linq;
using ToDoModel;

namespace ToDoFormApp
{
    public class MainPresenter
    {
        private ToDo model;
        private IMainView view;

        public MainPresenter(IMainView view, ToDo model)
        {
            this.view = view;
            this.model = model;

            this.model.PropertyChanged += (sender, e) =>
            {
                if (new[] { nameof(ToDo.Count), nameof(ToDo.DoneCount) }.Contains(e.PropertyName))
                {
                    this.view.SetTitle(model.Count, model.DoneCount);
                }
            };
        }
    }
}