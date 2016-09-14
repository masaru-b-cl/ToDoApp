using System;
using System.ComponentModel;
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

            this.model.PropertyChanged += ModelPropertyChanged;
        }

        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (new[] { nameof(model.Count), nameof(model.DoneCount) }.Contains(e.PropertyName))
            {
                view.SetTitle(model.Count, model.DoneCount);
            }

            if (e.PropertyName == nameof(model.AddingTaskContent))
            {
                view.SetAddingTaskContent(model.AddingTaskContent);
            }

            if (e.PropertyName == nameof(model.CanAdd))
            {
                view.SetCanAdd(model.CanAdd);
            }

            if (e.PropertyName == nameof(model.CanClear))
            {
                view.SetCanClear(model.CanClear);
            }
        }

        public void SetAddingTaskContent(string value)
        {
            model.AddingTaskContent = value;
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
        }

        public void ClearTasks()
        {
            model.Clear();
        }

        public void RemoveTask(int index)
        {
            model.RemoveTask(index);
        }
    }
}