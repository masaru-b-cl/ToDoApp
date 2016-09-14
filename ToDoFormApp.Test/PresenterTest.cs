using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using ToDoModel;
using System.Windows.Forms;

namespace ToDoFormApp.Test
{
    [TestClass]
    public class タイトル
    {
        [TestMethod]
        public void タスクを追加したらタイトルが設定されるか()
        {
            var mock = new Mock<IMainView>();
            IMainView view = mock.Object;

            var model = new ToDo();

            var presenter = new MainPresenter(view, model);

            model.AddingTaskContent = "x";
            model.AddTask();

            mock.Verify(v => v.SetTitle(1, 0));
        }

        [TestMethod]
        public void タスクを完了したらタイトルが設定されるか()
        {
            var mock = new Mock<IMainView>();
            IMainView view = mock.Object;

            var model = new ToDo();

            model.AddingTaskContent = "x";
            model.AddTask();

            var presenter = new MainPresenter(view, model);

            model.Items[0].Done = true;

            mock.Verify(v => v.SetTitle(1, 1));
        }
    }

    [TestClass]
    public class タスク追加
    {
        [TestMethod]
        public void タスク内容を指定してタスクを追加できる()
        {
            var mock = new Mock<IMainView>();
            IMainView view = mock.Object;

            var model = new ToDo();

            var presenter = new MainPresenter(view, model);

            presenter.AddingTaskContent = "x";
            presenter.AddTask();

            Assert.AreEqual("x", model.Items[0].Content);
        }

        [TestMethod]
        public void 重複タスクを追加しようとしたらVに確認メッセージを表示する()
        {
            var mock = new Mock<IMainView>();

            mock.Setup(v => v.ShowAddingConfirmationDialog()).Returns(DialogResult.Yes);

            IMainView view = mock.Object;

            var model = new ToDo();

            var presenter = new MainPresenter(view, model);

            presenter.AddingTaskContent = "x";
            presenter.AddTask();

            presenter.AddingTaskContent = "x";
            presenter.AddTask();

            mock.Verify(v => v.ShowAddingConfirmationDialog());

            Assert.AreEqual("x", model.Items[1].Content);
        }
    }
}
