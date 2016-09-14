using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoModel;

namespace ToDoFormApp.Test
{
    [TestClass]
    public class PresenterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMainView view = null;
            new Presenter(view: view, model: new ToDo());
        }
    }
}
