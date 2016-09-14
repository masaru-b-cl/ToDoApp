using System;
using System.Linq;
using System.Windows.Forms;
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

        public string AddingTaskContent {
            get
            {
                return model.AddingTaskContent;
            }
            set
            {
                model.AddingTaskContent = value;
                view.SetCanAdd(model.CanAdd);
            }
        }

        public void AddTask()
        {
            if (model.ContainsSameTask)
            {
                if (view.ShowAddingConfirmationDialog() != DialogResult.Yes)
                {
                    return;
                }
            }

            model.AddTask();

            view.SetAddingTaskContent(model.AddingTaskContent);
        }
    }
}