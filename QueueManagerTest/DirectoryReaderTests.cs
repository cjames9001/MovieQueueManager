using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;

namespace QueueManagerTest
{
    [TestFixture]
    public class DirectoryReaderTests
    {
        private DirectoryReader _directoryReader;
        private string path;

        [SetUp]
        public void SetUp()
        {
            _directoryReader = new DirectoryReader();
            path = @"..\..\TestDir\";
        }

        [Test]
        public void TestAddFilesInDirectoryToList()
        {
            Assert.AreEqual(new List<string> { { path + "a1.iso" }, { path + "a2.iso" }, { path + "a3.iso" }, { path + "a4.iso - Shortcut.lnk" } }, _directoryReader.GetListOfMoviesFromDirectory(path));
        }

        [Test]
        public void TestAddFilesFromNullDirectory()
        {
            Assert.AreEqual(new List<string>(), _directoryReader.GetListOfMoviesFromDirectory(""));
        }

        [Test]
        public void TestCreateDictionaryForNamesAndPaths()
        {
            Assert.AreEqual(new Dictionary<string, string> { { path + "a1.iso", "a1" }, { path + "a2.iso", "a2" }, { path + "a3.iso", "a3" }, { path + "a4.iso - Shortcut.lnk", "a4" } },
                _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(path)));
        }

        [Test]
        public void TestGetListOfFileNames()
        {
            Dictionary<string, string> dictionaryOfPathsAndNames = _directoryReader.CreateDictionaryForNamesAndPaths(_directoryReader.GetListOfMoviesFromDirectory(path));
            Assert.AreEqual(new List<string> { { "a1" }, { "a2" }, { "a3" }, { "a4" } }, _directoryReader.GetListOfFileNames(dictionaryOfPathsAndNames));
        }
    }
}
