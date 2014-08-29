namespace _02.DirectoryTraverserBFS
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DirectoryTraverser
    {
        private static List<string> files = new List<string>();

        public static void Main()
        {
            string rootPath = @"C:\Program Files";
            string fileExtension = "*.exe";

            TraverseDirectory(rootPath, fileExtension);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        private static void TraverseDirectory(string currentPath, string fileExtension)
        {
            try
            {
                string[] currentDirFiles = Directory.GetFiles(currentPath, fileExtension);
                files.AddRange(currentDirFiles);
            }
            catch (UnauthorizedAccessException e)
            {
                return;
            }

            string[] curretDirDirectories = Directory.GetDirectories(currentPath);
            foreach (var dir in curretDirDirectories)
            {
                TraverseDirectory(dir, fileExtension);
            }
        }
    }
}