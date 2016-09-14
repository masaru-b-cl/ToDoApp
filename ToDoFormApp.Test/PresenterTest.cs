using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using ToDoModel;


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
}
