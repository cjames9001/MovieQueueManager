using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;
using System.IO;
using System.Text;
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
        private string[] filesInUpperLevelFolder = new string[4] { "a1.iso", "a2.iso", "a3.iso", "a4.iso - Shortcut.lnk" };

        [SetUp]
        public void SetUp()
        {
            _directoryReader = new DirectoryReader();
            upperLevelFolderName = @"..\..\TestDir\";
            pathString = System.IO.Path.GetFullPath(upperLevelFolderName);
            //Create folder
            System.IO.Directory.CreateDirectory(pathString);
            //Create files in folder
            for(int i = 0; i < filesInUpperLevelFolder.Length; i++)
            {
                appendedPathString = System.IO.Path.Combine(pathString, filesInUpperLevelFolder[i]);
                System.IO.File.Create(appendedPathString);
            }
        }

        [Test]
        public void TestAddFilesInDirectoryToList()
        {
            Assert.AreEqual(new List<string> { { upperLevelFolderName + "a1.iso" }, { upperLevelFolderName + "a2.iso" }, { upperLevelFolderName + "a3.iso" }, { upperLevelFolderName + "a4.iso - Shortcut.lnk" } }, _directoryReader.GetListOfMoviesFromDirectory(upperLevelFolderName));
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
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            //delete directory
            System.IO.Directory.Delete(pathString, true);
        }
    }
}
