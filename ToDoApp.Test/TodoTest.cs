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
}
