using System.Windows.Forms;

namespace ToDoFormApp
{
    public interface IMainView
    {
        void SetTitle(int count, int doneCount);
        DialogResult ShowAddingConfirmationDialog();
    }
}