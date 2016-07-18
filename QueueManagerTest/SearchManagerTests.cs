using System.Collections.Generic;
using NUnit.Framework;
using QueueManager;

namespace QueueManagerTest
{
    [TestFixture]
    public class SearchManagerTests
    {
        private SearchManager _searchManager;

        [SetUp]
        public void SetUp()
        {
            _searchManager = new SearchManager();
        }

        [Test]
        public void TestTokenizeNoWords()
        {
            Assert.AreEqual(new List<string>(), _searchManager.TokenizeWords(""));
        }
        
        [Test]
        public void TestTokenizeOneWords()
        {
            Assert.AreEqual(new List<string>() { "split" }, _searchManager.TokenizeWords("split"));
        }

        [Test]
        public void TestTokenizeTwoWords()
        {
            Assert.AreEqual(new List<string>() { "split", "this" }, _searchManager.TokenizeWords("split this"));
        }

        [Test]
        public void TestTokenizeManyWords()
        {
            Assert.AreEqual(new List<string>() { "split", "this", "into", "many", "tokens" }, _searchManager.TokenizeWords("split this into many tokens"));
        }

        [Test]
        public void TestSearchForItemWithOneMatchingWord()
        {
            List<string> listToSearch = new List<string>() { "word", "alpha", "beta" };
            Assert.AreEqual(new List<string>() { "word" }, _searchManager.SearchFor(listToSearch, "word"));
        }

        [Test]
        public void TestSearchForItemWithTwoMatchingWordsInOrder()
        {
            List<string> listToSearch = new List<string>() { "the word", "alpha", "beta" };
            Assert.AreEqual(new List<string>() { "the word" }, _searchManager.SearchFor(listToSearch, "the word"));
        }

        [Test]
        public void TestSearchForItemWithTwoMatchingWordsNotInOrder()
        {
            List<string> listToSearch = new List<string>() { "the word", "alpha", "beta" };
            Assert.AreEqual(new List<string>() { "the word" }, _searchManager.SearchFor(listToSearch, "word the"));
        }

        [Test]
        public void TestSearchForItemWhenUpperCaseIsUsed()
        {
            List<string> listToSearch = new List<string>() { "The word", "alpha", "beta" };
            Assert.AreEqual(new List<string>() { "The word" }, _searchManager.SearchFor(listToSearch, "the"));
        }

        [Test]
        public void TestSearchMultipleItemsWhenASpaceIsPresent()
        {
            List<string> listToSearch = new List<string>() { "The word", "alpha add", "beta sdf" };
            Assert.AreEqual(new List<string>() { "The word" }, _searchManager.SearchFor(listToSearch, "the "));
        }

        [Test]
        public void TestSearchMultipleItemsWhenASpaceIsPresentWihTwoWords()
        {
            List<string> listToSearch = new List<string>() { "The word", "alpha add", "beta sdf" };
            Assert.AreEqual(new List<string>() { "The word" }, _searchManager.SearchFor(listToSearch, "the wo"));
        }
    }
}
