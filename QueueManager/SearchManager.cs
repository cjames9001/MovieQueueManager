using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueueManager
{
    public class SearchManager
    {
        public List<string> SearchFor(List<string> listToSearch, string searchTerm)
        {
            List<string> tokenizedWordsToSearch = TokenizeWords(searchTerm);
            List<string> searchedList = new List<string>();

            if (searchTerm == "")
            {
                return listToSearch;
            }

            foreach (var item in listToSearch)
            {
                int tokenCount = 0;
                foreach (var token in tokenizedWordsToSearch)
                {
                    if (item.ToLower().Contains(token.ToLower()) && !searchedList.Contains(item))
                    {
                        tokenCount++;
                    }
                }
                if (tokenCount == tokenizedWordsToSearch.Count)
                {
                    searchedList.Add(item);
                }
            }

            return searchedList;
        }

        internal List<string> TokenizeWords(string stringToBeTokenized)
        {
            List<string> tokenizedListOfWords = new List<string>();
            foreach (char space in stringToBeTokenized)
            {
                tokenizedListOfWords = stringToBeTokenized.Split(' ').ToList<string>();
            }

            tokenizedListOfWords = RemoveSpacesFromTokens(tokenizedListOfWords);

            return tokenizedListOfWords;
        }

        private List<string> RemoveSpacesFromTokens(List<string> tokenizedListOfWords)
        {
            List<string> tokensWithoutSpaces = new List<string>();
            foreach (var token in tokenizedListOfWords)
            {
                if (token != "")
                {
                    tokensWithoutSpaces.Add(token);
                }
                
            }

            return tokensWithoutSpaces;
        }
    }
}
