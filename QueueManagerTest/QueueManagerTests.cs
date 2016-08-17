using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;
using System.IO;
using System;  

namespace QueueManagerTest
{
    [TestFixture]
    public class QueueManagerTests
    {
        QueueManagers _queueManager;
        string _pathString;
        string _upperLevelFolderName;
        string _testFileName;
        TextWriter _testFile;
        string _pathWithFile;
        List<string> _linesInFile;

        [SetUp]
        public void SetUp()
        {
            _queueManager = new QueueManagers();
            _upperLevelFolderName = @"..\..\Test Files\";
            _pathString = Path.GetFullPath(_upperLevelFolderName);
            if (!Directory.Exists(_pathString))
            {
                Directory.CreateDirectory(_pathString);
            }
            _testFileName = "testQueue.txt";
            _pathWithFile = Path.Combine(_pathString, _testFileName);
            File.Create(_pathWithFile).Dispose();
            _testFile = new StreamWriter(_pathWithFile);
            _linesInFile = new List<string> { "Cherry Bomb (2010)", "The Tyler Perry Collection: Why Did I Get Married? - Stage Play (2006)", "Joe Dirt (2001)", "Kicking and Screaming (2005)"  };
            foreach(string line in _linesInFile)
            {
                _testFile.WriteLine(line);
            }
            _testFile.Close();
        }
        [Test]
        public void TestAddMovieToQueue()
        {
            Assert.IsTrue(_queueManager.AddMovieToQueue(new List<string>() { "TestMovie" }));
        }

        [Test]
        public void TestAddEmptyMovieToQueue()
        {
            _queueManager.AddMovieToQueue(new List<string>() { "" });
            Assert.AreEqual(new List<string>(), _queueManager.GetMovieList());
        }

        [Test]
        public void TestAddDuplicateMovieToQueue()
        {
            _queueManager.AddMovieToQueue(new List<string> {"testmovie", "testmovie"});
            Assert.AreEqual(new List<string> { { "testmovie" } }, _queueManager.GetMovieList());
        }

        [Test]
        public void TestDeleteMovieFromQueueWhenTwoMoviesExist()
        {
            _queueManager.AddMovieToQueue(new List<string>() {"TestMovie", "TestMovie2"});
            _queueManager.DeleteMovieFromQueue(new string[] { "TestMovie" });
            Assert.AreEqual(new List<string> { { "TestMovie2" } }, _queueManager.GetMovieList());
        }

        [Test]
        public void TestDeleteMovieFromQueueWhenThreeMoviesExist()
        {
            _queueManager.AddMovieToQueue(new List<string>() { "TestMovie", "TestMovie2", "TestMovie3" });
            _queueManager.DeleteMovieFromQueue(new string[] { "TestMovie3" });
            Assert.AreEqual(new List<string> { { "TestMovie" }, { "TestMovie2" } }, _queueManager.GetMovieList());
        }

        [Test]
        public void TestDeleteTwoMoviesFromQueue()
        {
            _queueManager.AddMovieToQueue(new List<string>() { "TestMovie", "TestMovie2", "TestMovie3" });
            _queueManager.DeleteMovieFromQueue(new string[] { "TestMovie3", "TestMovie2" });
            Assert.AreEqual(new List<string> { { "TestMovie" } }, _queueManager.GetMovieList());
        }

        [Test]
        public void TestGetTheListOfMovies()
        {
            _queueManager.AddMovieToQueue(new List<string>() {"TestMovie", "TestMovie2"});
            List<string> checkedMovies = new List<string> { { "TestMovie" }, { "TestMovie2" } };
            Assert.AreEqual(checkedMovies, _queueManager.GetMovieList());
        }

        [Test]
        public void TestLoadListOfMoviesFromTextFile()
        {
            _queueManager.LoadListOfMoviesFromTextFile(_pathWithFile);
            List<string> checkedMovies = new List<string> { { "Cherry Bomb (2010)" }, 
            {"The Tyler Perry Collection: Why Did I Get Married? - Stage Play (2006)" }, { "Joe Dirt (2001)" }, 
            {"Kicking and Screaming (2005)" } };
            Assert.AreEqual(checkedMovies, _queueManager.GetMovieList());
        }

        [Test]
        public void TestSortListOfMovies()
        {
            _queueManager.LoadListOfMoviesFromTextFile(_pathWithFile);
            _queueManager.SortListOfMovies();
            List<string> checkedMovies = new List<string> { { "Cherry Bomb (2010)" }, 
            { "Joe Dirt (2001)" }, {"Kicking and Screaming (2005)" }, {"The Tyler Perry Collection: Why Did I Get Married? - Stage Play (2006)" }, };
            Assert.AreEqual(checkedMovies, _queueManager.GetMovieList());
        }

        [Test]
        public void TestCopyListForSaveOnQuitUpdatesTheComparerList()
        {
            _queueManager.AddMovieToQueue(new List<string> { { "movie" } });
            _queueManager.CopyListForSaveOnQuit();
            Assert.AreEqual(new List<string> { { "movie" } }, _queueManager._listToCompareToForChanges);
        }

        [Test]
        public void TestComparerListDoesNotReferenceQueue()
        {
            _queueManager.AddMovieToQueue(new List<string> { { "movie" } });
            _queueManager.CopyListForSaveOnQuit();
            _queueManager.AddMovieToQueue(new List<string> { { "movie2" } });
            Assert.AreEqual(new List<string> { { "movie" } }, _queueManager._listToCompareToForChanges);
        }

        [Test]
        public void TestQueueHasBeenModifiedAfterCopyingList()
        {
            _queueManager.AddMovieToQueue(new List<string> { { "movie" } });
            _queueManager.CopyListForSaveOnQuit();
            _queueManager.AddMovieToQueue(new List<string> { { "movie2" } });
            Assert.IsTrue(_queueManager.QueueHasBeenModified());
        }
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Directory.Delete(_pathString, true);
        }
    }
}
