using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace QueueManager
{
    public class QueueManagers
    {
        private List<string> _movieQueue = new List<string>();
        internal List<string> _listToCompareToForChanges = new List<string>();

        public bool AddMovieToQueue(List<string> moviesToAdd)
        {
            try
            {
                foreach (var item in moviesToAdd)
                {
                    if (!_movieQueue.Contains(item) && item !="")
                    {
                        _movieQueue.Add(item);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void DeleteMovieFromQueue(string[] moviesToDelete)
        {
            foreach (var item in moviesToDelete)
            {
                _movieQueue.Remove(item);
            }
        }

        public List<string> GetMovieList()
        {
            return _movieQueue;
        }

        public void LoadListOfMoviesFromTextFile(string path)
        {
            List<string> moviesToBeAdded = File.ReadAllLines(path).ToList<string>();

            foreach(var item in moviesToBeAdded)
            {
                AddMovieToQueue(moviesToBeAdded);
            }
        }

        public void SortListOfMovies()
        {
            _movieQueue.Sort();
        }

        public void CopyListForSaveOnQuit()
        {
            _listToCompareToForChanges = _movieQueue.ToList();
        }

        public bool QueueHasBeenModified()
        {
            return !(new HashSet<string>(_listToCompareToForChanges).SetEquals(_movieQueue));
        }
    }
}
