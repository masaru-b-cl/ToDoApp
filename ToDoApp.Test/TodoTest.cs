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
    }
}
