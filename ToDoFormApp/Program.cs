﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoModel;

namespace ToDoFormApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var model = new ToDo();
            var presenter = new MainPresenter(model);
            var form = new ToDoForm(presenter);
            presenter.SetView(form);
            Application.Run(form);
        }
    }
}
