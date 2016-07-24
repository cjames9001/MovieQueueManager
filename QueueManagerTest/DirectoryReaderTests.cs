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
        private string upperLevelFolderName;
        private string pathString;
        private string appendedPathString;
        private List<string> filesInUpperLevelFolder;

        [SetUp]
        public void SetUp()
        {
            _directoryReader = new DirectoryReader();
            upperLevelFolderName = @"..\..\TestDir\";
            pathString = Path.GetFullPath(upperLevelFolderName);
            Directory.CreateDirectory(pathString);
            filesInUpperLevelFolder = new List<string> { "a1.iso", "a2.iso", "a3.iso", "a4.iso - Shortcut.lnk" };
            foreach (string file in filesInUpperLevelFolder)
            {
                appendedPathString = Path.Combine(pathString, file);
                File.Create(appendedPathString);
            }
        }

        [Test]
        public void TestAddFilesInDirectoryToList()
        {
            List<string> testList = new List<string>();
            foreach(string fileName in filesInUpperLevelFolder)
            {
                testList.Add(upperLevelFolderName + fileName);
            }
            Assert.AreEqual(testList, _directoryReader.GetListOfMoviesFromDirectory(upperLevelFolderName));
        }

        [Test]
        public void TestAddFilesFromNullDirectory()
        {
            Assert.AreEqual(new List<string>(), _directoryReader.GetListOfMoviesFromDirectory(""));
        }

        [Test]
        public void TestCreateDictionaryForNamesAndPaths()
        {
            Assert.AreEqual(new Dictionary<string, string> { { upperLevelFolderName + "a1.iso", "a1" }, { upperLevelFolderName + "a2.iso", "a2" }, { upperLevelFolderName + "a3.iso", "a3" }, { upperLevelFolderName + "a4.iso - Shortcut.lnk", "a4" } },
                _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(upperLevelFolderName)));
        }

        [Test]
        public void TestGetListOfFileNames()
        {
            Dictionary<string, string> dictionaryOfPathsAndNames = _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(upperLevelFolderName));
            Assert.AreEqual(new List<string> { { "a1" }, { "a2" }, { "a3" }, { "a4" } }, _directoryReader.GetListOfFileNames(dictionaryOfPathsAndNames));
        }

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Directory.Delete(pathString, true);
        }
    }
}
