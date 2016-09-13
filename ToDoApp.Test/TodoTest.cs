using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            todo.AddingTaskContent = "x";
            todo.AddTask();
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
            todo.AddingTaskContent = "x";
            todo.AddTask();
            int doneCount = todo.DoneCount;
            Assert.AreEqual(0, doneCount);
        }

        [TestMethod]
        public void 完了タスクがあればその件数()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();
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
            todo.AddingTaskContent = "x";
            todo.AddTask();
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
                todo.AddingTaskContent = "";
                todo.AddTask();

                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }
        }

        [TestMethod]
        public void タスク追加後は追加中タスク内容をクリアする()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();

            Assert.IsNull(todo.AddingTaskContent);
        }

        [TestMethod]
        public void タスクが空なら同じ内容のタスクなし()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            Assert.IsTrue(todo.ContainsSameTask);
        }

        [TestMethod]
        public void 同じ内容のタスクがある()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();

            todo.AddingTaskContent = "x";

            Assert.IsFalse(todo.ContainsSameTask);
        }
    }

    [TestClass]
    public class タスク完了状態
    {
        [TestMethod]
        public void 追加直後のタスクは未完了()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();
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
            todo.AddingTaskContent = "x";
            todo.AddTask();

            todo.RemoveTask(0);

            Assert.AreEqual(0, todo.Count);
        }
    }

    [TestClass]
    public class タスク一覧
    {
        [TestMethod]
        public void タスクを列挙できる()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();

            IEnumerator enumerator = todo.GetEnumerator();

            {
                Assert.IsTrue(enumerator.MoveNext());
                var item = (ToDoItem)enumerator.Current;
                Assert.AreEqual("x", item.Content);
            }

        }

        [TestMethod]
        public void タスクを型指定して列挙できる()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();

            IEnumerator<ToDoItem> enumerator = todo.GetEnumerator();

            {
                Assert.IsTrue(enumerator.MoveNext());
                var item = enumerator.Current;
                Assert.AreEqual("x", item.Content);
            }

        }
    }

    [TestClass]
    public class タスククリア
    {
        [TestMethod]
        public void 初期状態はクリア不可()
        {
            var todo = new ToDo();

            Assert.IsFalse(todo.CanClear);
        }

        [TestMethod]
        public void タスク追加したらクリア可能()
        {
            var todo = new ToDo();
            todo.AddingTaskContent = "x";
            todo.AddTask();

            Assert.IsTrue(todo.CanClear);
        }

    }
}
