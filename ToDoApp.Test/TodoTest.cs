using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoApp.Test
{
    [TestClass]
    public class タスク件数
    {
        [TestMethod]
        public void 初期状態ではタスクは0件()
        {
            var todo = new ToDo();
            int count = todo.Count;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void タスクを追加したら1件()
        {
            var todo = new ToDo();
            todo.AddTask("x");
            int count = todo.Count;
            Assert.AreEqual(1, count);
        }
    }

    [TestClass]
    public class 完了タスク件数
    {
        [TestMethod]
        public void 完了タスクがなければ0件()
        {
            var todo = new ToDo();
            todo.AddTask("x");
            int doneCount = todo.DoneCount;
            Assert.AreEqual(0, doneCount);
        }

        [TestMethod]
        public void 完了タスクがあればその件数()
        {
            var todo = new ToDo();
            todo.AddTask("x");
            todo[0].Done = true;
            int doneCount = todo.DoneCount;
            Assert.AreEqual(1, doneCount);
        }
    }

    [TestClass]
    public class タスク追加
    {
        [TestMethod]
        public void タスク内容を指定してタスクが追加できる()
        {
            var todo = new ToDo();
            todo.AddTask("x");
            ToDoItem toDoItem = todo[0];
            string content = toDoItem.Content;
            Assert.AreEqual("x", content);
        }

        [TestMethod]
        public void タスク内容が空は追加できない()
        {
            try
            {
                var todo = new ToDo();
                todo.AddTask("");

                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }
    }

    [TestClass]
    public class タスク完了状態
    {
        [TestMethod]
        public void 追加直後のタスクは未完了()
        {
            var todo = new ToDo();
            todo.AddTask("x");
            ToDoItem toDoItem = todo[0];
            bool done = toDoItem.Done;
            Assert.AreEqual(false, done);
        }

        [TestMethod]
        public void タスクの完了状態を変更できる()
        {
            var toDoItem = new ToDoItem("x");
            toDoItem.Done = true;
            Assert.IsTrue(toDoItem.Done);
        }
    }

    [TestClass]
    public class タスク削除
    {
        [TestMethod]
        public void タスクを削除できる()
        {
            var todo = new ToDo();
            todo.AddTask("x");

            todo.RemoveTask(0);

            Assert.AreEqual(0, todo.Count);
        }
    }
}
