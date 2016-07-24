using System;
using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;

namespace QueueManagerTest
{
    [TestFixture]
    public class QueueFileManagerTests
    {
        List<string> _movieList;
        QueueFileManager _queueFileManager;

        [SetUp]
        public void SetUp()
        {
            _movieList = new List<string>();
            _movieList.Add("movie1");
            _movieList.Add("movie2");
            _queueFileManager = new QueueFileManager();
        }

        [Test]
        public void TestSaveAndLoadFile()
        {
            //TODO: This and the invalid file below are not cleaned up after a test is run.
            _queueFileManager.SaveFile("NewFile", _movieList);
            Assert.AreEqual(_queueFileManager.OpenFile("NewFile"), _movieList);
        }

        [Test]
        public void TestInvalidFileNameWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("?", _movieList), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestDirectoryNotFoundWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("CON/test", _movieList), Throws.Exception.TypeOf<System.IO.DirectoryNotFoundException>());
        }

        [Test]
        public void TestEmptyFileNameWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("", _movieList), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestOpenInvalidFileThrowsException()
        {
            System.IO.File.WriteAllText("InvalidFile", "invalidtestfile");
            Assert.That(() => _queueFileManager.OpenFile("InvalidFile"), Throws.Exception.TypeOf<System.Runtime.Serialization.SerializationException>());
        }
    }
}
