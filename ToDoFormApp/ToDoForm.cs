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
    public partial class ToDoForm : Form
    {
        private readonly ToDo toDo;

        public ToDoForm()
        {
            InitializeComponent();
        }

        public ToDoForm(ToDo toDo) : this()
        {
            this.toDo = toDo;

            toDo.PropertyChanged += ToDoPropertyChanged;
        }

        private void ToDoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (new[] { nameof(ToDo.Count), nameof(ToDo.DoneCount) }.Contains(e.PropertyName))
            {
                SetTitle();
            }
        }

        private void SetTitle()
        {
            Text = $"ToDoリスト ( {toDo.DoneCount} / {toDo.Count} )";
        }

        private void ToDoForm_Load(object sender, EventArgs e)
        {
            toDoBindingSource.DataSource = toDo;
            toDoItemBindingSource.DataSource = toDo.Items;

            SetTitle();
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
            if (toDo.ContainsSameTask)
            {
                if (MessageBox.Show("同じタスクが既に登録されています。本当に追加しますか？", "ToDoリスト", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            }

            toDo.AddTask();
            toDoItemBindingSource.ResetBindings(false);

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
                    var item = toDo.Items[currentRowIndex];
                    var done = !item.Done;
                    dataGridView1[0, currentRowIndex].Value = done;
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
            toDo.RemoveTask(index);
            toDoItemBindingSource.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toDo.Clear();
            toDoItemBindingSource.ResetBindings(false);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var taskCell = dataGridView1[1, e.RowIndex];
            var currentFont = taskCell.InheritedStyle.Font;

            if (toDo.Items[e.RowIndex].Done)
            {
                taskCell.Style.Font = new Font(currentFont, currentFont.Style | FontStyle.Strikeout);
            }
            else
            {
                taskCell.Style.Font = new Font(currentFont, currentFont.Style & ~FontStyle.Strikeout);
            }
        }
    }
}
