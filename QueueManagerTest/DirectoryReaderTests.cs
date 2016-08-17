using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;
using System.IO;
using System;

namespace QueueManagerTest
{
    [TestFixture]
    public class DirectoryReaderTests
    {
        private DirectoryReader _directoryReader;
        private string _upperLevelFolderName;
        private string _pathString;
        private string _appendedPathString;
        private List<string> _filesInUpperLevelFolder;
        private Dictionary<string, string> _testFiles;
        private string _appendedFileName;

        [SetUp]
        public void SetUp()
        {
            _directoryReader = new DirectoryReader();
            _upperLevelFolderName = @"..\..\Test Files\";
            _pathString = Path.GetFullPath(_upperLevelFolderName);
            Directory.CreateDirectory(_pathString);
            _testFiles = new Dictionary<string, string>
            {
                {"a1",".iso" },
                {"a2",".iso" },
                {"a3",".iso" },
                {"a4",".iso - Shortcut.lnk" }
            };
            _filesInUpperLevelFolder = new List<string>();
            foreach(KeyValuePair<string,string> item in _testFiles)
            {
                _appendedFileName = item.Key + item.Value;
                _filesInUpperLevelFolder.Add(_appendedFileName);
                _appendedPathString = Path.Combine(_pathString, _appendedFileName);
                File.Create(_appendedPathString);
            }
        }

        [Test]
        public void TestAddFilesInDirectoryToList()
        {
            List<string> testList = new List<string>();
            foreach(string fileName in _filesInUpperLevelFolder)
            {
                testList.Add(_upperLevelFolderName + fileName);
            }
            Assert.AreEqual(testList, _directoryReader.GetListOfMoviesFromDirectory(_upperLevelFolderName));
        }

        [Test]
        public void TestAddFilesFromNullDirectory()
        {
            Assert.AreEqual(new List<string>(), _directoryReader.GetListOfMoviesFromDirectory(""));
        }

        [Test]
        public void TestCreateDictionaryForNamesAndPaths()
        {
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            foreach(KeyValuePair<string,string> item in _testFiles)
            {
                testDict.Add(_upperLevelFolderName + item.Key + item.Value, item.Key);
            }
            Assert.AreEqual(testDict, _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(_upperLevelFolderName)));
        }

        [Test]
        public void TestGetListOfFileNames()
        {
            List<string> testList = new List<string>();
            foreach(KeyValuePair<string,string> item in _testFiles)
            {
                testList.Add(item.Key);
            }
            Dictionary<string, string> dictionaryOfPathsAndNames = _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(_upperLevelFolderName));
            Assert.AreEqual(testList, _directoryReader.GetListOfFileNames(dictionaryOfPathsAndNames));
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