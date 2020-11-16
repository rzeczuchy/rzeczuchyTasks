using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using rzeczuchyTasks.Model;

namespace rzeczuchyTask.UnitTests
{
    [TestClass]
    public class DataReaderWriterTests
    {
        [TestMethod]
        public void NewToDoId_ReturnsProperId()
        {
            var testList = new List<ToDo>();

            for (int i = 0; i < 5; i++)
            {
                testList.Add(new ToDo(i, "test", false, null));

                Assert.AreEqual(DataReaderWriter.NewToDoId(testList), testList.Count);
            }
        }
    }
}
