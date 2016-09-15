﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoApp
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
            if (new[] { nameof(ToDo.Count), nameof(ToDo.DoneCount)}.Contains(e.PropertyName))
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
            if (toDo.ContainsSameTask)
            {
                if (MessageBox.Show("同じタスクが既に登録されています。本当に追加しますか？", "ToDoリスト", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
            }

            toDo.AddTask();
            toDoItemBindingSource.ResetBindings(false);
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
    }
}
