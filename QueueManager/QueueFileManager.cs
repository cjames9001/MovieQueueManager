using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QueueManager
{
    public class QueueFileManager
    {
        public void SaveFile(string fileName, List<string> _movieList)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, _movieList);
            stream.Close();
        }

        public List<string> OpenFile(string fileName)
        {
            List<string> listToLoad;
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            listToLoad = (List<string>)bFormatter.Deserialize(stream);
            stream.Close();
            return listToLoad;
        }
    }
}
