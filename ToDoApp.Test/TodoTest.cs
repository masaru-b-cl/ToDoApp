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
            var toDo = new ToDo();
            int count = toDo.Count;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void タスクを追加したら1件()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();
            int count = toDo.Count;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void タスクを追加したらタスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.Count)) raised = true;
            };

            toDo.AddTask();

            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void タスクを削除したらタスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.Count)) raised = true;
            };

            toDo.RemoveTask(0);

            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void タスクをクリアしたらタスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.Count)) raised = true;
            };

            toDo.Clear();

            Assert.IsTrue(raised);
        }
    }

    [TestClass]
    public class 完了タスク件数
    {
        [TestMethod]
        public void 完了タスクがなければ0件()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();
            int doneCount = toDo.DoneCount;
            Assert.AreEqual(0, doneCount);
        }

        [TestMethod]
        public void 完了タスクがあればその件数()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();
            toDo.Items[0].Done = true;
            int doneCount = toDo.DoneCount;
            Assert.AreEqual(1, doneCount);
        }

        [TestMethod]
        public void タスクの完了状態を変更したら完了タスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.DoneCount)) raised = true;
            };

            toDo.Items[0].Done = true;

            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void タスクを削除したら完了タスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.DoneCount)) raised = true;
            };

            toDo.RemoveTask(0);

            Assert.IsTrue(raised);
        }
        [TestMethod]
        public void タスクをクリアしたら完了タスク件数の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.DoneCount)) raised = true;
            };

            toDo.Clear();

            Assert.IsTrue(raised);
        }
    }

    [TestClass]
    public class タスク追加
    {
        [TestMethod]
        public void タスク内容を指定してタスクが追加できる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();
            ToDoItem toDoItem = toDo.Items[0];
            string content = toDoItem.Content;
            Assert.AreEqual("x", content);
        }

        [TestMethod]
        public void タスク内容が空は追加できない()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "";

            Assert.IsFalse(toDo.CanAdd);

            toDo.AddTask();

            Assert.AreEqual(0, toDo.Count);
        }

        [TestMethod]
        public void タスク追加後は追加中タスク内容をクリアする()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            Assert.IsNull(toDo.AddingTaskContent);
        }

        [TestMethod]
        public void タスクが空なら同じ内容のタスクなし()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            Assert.IsFalse(toDo.ContainsSameTask);
        }

        [TestMethod]
        public void 同じ内容のタスクがある()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            toDo.AddingTaskContent = "x";

            Assert.IsTrue(toDo.ContainsSameTask);
        }
    }

    [TestClass]
    public class タスク完了状態
    {
        [TestMethod]
        public void 追加直後のタスクは未完了()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();
            ToDoItem toDoItem = toDo.Items[0];
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
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            toDo.RemoveTask(0);

            Assert.AreEqual(0, toDo.Count);
        }
    }

    [TestClass]
    public class タスク一覧
    {
        [TestMethod]
        public void タスクを型指定して列挙できる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            IEnumerator<ToDoItem> enumerator = toDo.Items.GetEnumerator();

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
            var toDo = new ToDo();

            Assert.IsFalse(toDo.CanClear);
        }

        [TestMethod]
        public void タスク追加したらクリア可能()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            Assert.IsTrue(toDo.CanClear);
        }

        [TestMethod]
        public void タスクをクリアできる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            toDo.Clear();

            Assert.AreEqual(0, toDo.Count);
        }

        [TestMethod]
        public void タスクを追加したらクリア可否の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.CanClear)) raised = true;
            };

            toDo.AddTask();

            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void タスクを削除したらクリア可否の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.CanClear)) raised = true;
            };

            toDo.RemoveTask(0);

            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void タスクをクリアしたらクリア可否の変更通知が行われる()
        {
            var toDo = new ToDo();
            toDo.AddingTaskContent = "x";
            toDo.AddTask();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.CanClear)) raised = true;
            };

            toDo.Clear();

            Assert.IsTrue(raised);
        }
    }

    [TestClass]
    public class タスク入力内容
    {
        [TestMethod]
        public void タスク入力内容の変更通知が行われる()
        {
            var toDo = new ToDo();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.AddingTaskContent)) raised = true;
            };

            toDo.AddingTaskContent = "x";

            Assert.IsTrue(raised);
        }
    }

    [TestClass]
    public class タスク入力可否
    {
        [TestMethod]
        public void タスク入力内容を変更するとタスク入力可否の変更通知が行われる()
        {
            var toDo = new ToDo();

            var raised = false;
            toDo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(toDo.CanAdd)) raised = true;
            };

            toDo.AddingTaskContent = "x";

            Assert.IsTrue(raised);
        }
    }
}
