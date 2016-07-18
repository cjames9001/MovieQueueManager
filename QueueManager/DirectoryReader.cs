using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QueueManager
{
    public class DirectoryReader
    {
        public List<string> GetListOfMoviesFromDirectory(string path)
        {
            try
            {
                Path.GetFullPath(path);
            }
            catch (System.ArgumentException)
            {
                return new List<string>();
            }

            return Directory.GetFiles(path).ToList<string>();
        }

        public Dictionary<string, string> CreateDictionaryForNamesAndPaths(List<string> pathValues)
        {
            Dictionary<string, string> nameAndPathDictionary = new Dictionary<string, string>();
            foreach (string item in pathValues)
            {
                nameAndPathDictionary.Add(item, RemoveShortcutText(Path.GetFileNameWithoutExtension(item)));
            }

            return nameAndPathDictionary;
        }

        public string RemoveShortcutText(string filename)
        {
            if (filename.Contains("Shortcut"))
            {
                filename = filename.Remove(filename.IndexOf(".iso"));
            }
            return filename;
        }

        public List<string> GetListOfFileNames(Dictionary<string, string> dictionaryOfPathsAndNames)
        {
            List<string> listOfFileNames = new List<string>();
            listOfFileNames = dictionaryOfPathsAndNames.Values.ToList();
            return listOfFileNames;
        }
    }
}
