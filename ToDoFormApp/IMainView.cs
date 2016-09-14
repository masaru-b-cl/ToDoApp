using System;
using System.ComponentModel;
using System.Windows.Forms;
using ToDoModel;

namespace ToDoFormApp
{
    public interface IMainView
    {
        void SetAddingTaskContent(string value);

        void SetCanAdd(bool value);

        void SetTitle(int count, int doneCount);

        DialogResult ShowAddingConfirmationDialog();
        void SetCanClear(bool v);
        void RefreshToDoItems(BindingList<ToDoItem> toDoItems);
    }
}