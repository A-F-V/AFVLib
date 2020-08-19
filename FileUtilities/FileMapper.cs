using System;
using System.IO;

namespace AFVLib.FileUtilities
{
    public static class FileMapper
    {
        public static void MapFileLocations(Action<string> mapper, string folder, Predicate<string> checker = null)
        {
            foreach (string file in Directory.EnumerateFiles(folder))
                if ((checker != null) & checker(file))
                    mapper(file);
        }
    }
}