using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToDoModel;

namespace ToDoFormApp
{
    public partial class ToDoForm : Form, IMainView
    {
        private readonly MainPresenter presenter;

        public ToDoForm()
        {
            InitializeComponent();
        }

        public ToDoForm(MainPresenter presenter) : this()
        {
            this.presenter = presenter;
        }

        public void SetTitle(int count, int doneCount)
        {
            Text = $"ToDoリスト ( {doneCount} / {count} )";
        }

        public DialogResult ShowAddingConfirmationDialog()
        {
            return MessageBox.Show("同じタスクが既に登録されています。本当に追加しますか？",
                "ToDoリスト",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
                );
        }

        public void SetAddingTaskContent(string value)
        {
            textBox1.Text = value;
        }

        public void SetCanAdd(bool value)
        {
            button1.Enabled = value;
        }

        public void SetCanClear(bool value)
        {
            button2.Enabled = value;
        }

        public void RefreshToDoItems(BindingList<ToDoItem> toDoItems)
        {
            dataGridView1.DataSource = toDoItems;
        }

        private void ToDoForm_Load(object sender, EventArgs e)
        {
            presenter.ClearTasks();
            presenter.SetAddingTaskContent(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            AddTask();
        }

        private void AddTask()
        {
            presenter.AddTask();

            textBox1.Focus();
        }


        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCellAddress.X == 0 && dataGridView1.CurrentCellAddress.Y != -1)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;

            var currentRowIndex = dataGridView1.CurrentRow.Index;
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (dataGridView1.CurrentCell.ColumnIndex == 0) return;
                    var done = (bool)dataGridView1[0, currentRowIndex].Value;
                    dataGridView1[0, currentRowIndex].Value = !done;
                    break;

                case Keys.Delete:
                    RemoveTask(currentRowIndex);
                    break;

                default:
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 2) return;

            RemoveTask(e.RowIndex);
        }

        private void RemoveTask(int index)
        {
            presenter.RemoveTask(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presenter.ClearTasks();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var taskCell = dataGridView1[1, e.RowIndex];
            var currentFont = taskCell.InheritedStyle.Font;

            var done = (bool)dataGridView1[0, e.RowIndex].Value;

            presenter.SetDone(e.RowIndex, done);

            if (done)
            {
                taskCell.Style.Font = new Font(currentFont, currentFont.Style | FontStyle.Strikeout);
            }
            else
            {
                taskCell.Style.Font = new Font(currentFont, currentFont.Style & ~FontStyle.Strikeout);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            presenter.SetAddingTaskContent(textBox1.Text);
        }
    }
}
