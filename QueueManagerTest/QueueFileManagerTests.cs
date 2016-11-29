using System;
using System.IO;
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
        TestManager _testManager;
        string _upperLevelFolderName;
        string _pathString;
        string _newFileName;
        string _newFilePath;
        string _invalidFileName;
        string _invalidFilePath;

        [SetUp]
        public void SetUp()
        {
            _movieList = new List<string>();
            _movieList.Add("movie1");
            _movieList.Add("movie2");
            _queueFileManager = new QueueFileManager();
            _testManager = new TestManager();
            _upperLevelFolderName = @"..\..\Test Files\";
            _pathString = Path.GetFullPath(_upperLevelFolderName);
            Directory.CreateDirectory(_pathString);
            _newFileName = "NewFile";
            _newFilePath = Path.Combine(_pathString, _newFileName);
            _invalidFileName = "InvalidFile";
            _invalidFilePath = Path.Combine(_pathString, _invalidFileName);
        }

        [Test]
        public void TestSaveAndLoadFile()
        {
            _queueFileManager.SaveFile(_newFilePath, _movieList);
            Assert.AreEqual(_queueFileManager.OpenFile(_newFilePath), _movieList);
        }

        [Test]
        public void TestInvalidFileNameWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("?", _movieList), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestDirectoryNotFoundWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("ThisDirectoryDoesNotExist/test", _movieList), Throws.Exception.TypeOf<System.IO.DirectoryNotFoundException>());
        }

        [Test]
        public void TestEmptyFileNameWhileSavingAFile()
        {
            Assert.That(() => _queueFileManager.SaveFile("", _movieList), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestOpenInvalidFileThrowsException()
        {
            File.WriteAllText(_invalidFilePath, "invalidtestfile");
            Assert.That(() => _queueFileManager.OpenFile(_invalidFilePath), Throws.Exception.TypeOf<System.Runtime.Serialization.SerializationException>());
        }
        [TearDown]
        public void TearDown()
        {
            _testManager.RemoveDirectory(_pathString);
        }
    }
}
