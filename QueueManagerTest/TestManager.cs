using System;
using System.IO;

namespace QueueManagerTest
{
    public class TestManager
    {
        public void RemoveDirectory(string directory)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Directory.Delete(directory, true);
        }
    }
}
