namespace _3dSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    // Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.
    public static class PathStorage
    {
        private static string fileName = @"../../Paths.txt";

        public static void SavePath(Path path)
        {
            StreamWriter writer = new StreamWriter(fileName, true);

            using (writer)
            {
                for (int i = 0; i < path.PathPoints.Count; i++)
                {
                    StringBuilder line = new StringBuilder();
                    line.Append(path[i].X);
                    line.Append(' ');
                    line.Append(path[i].Y);
                    line.Append(' ');
                    line.Append(path[i].Z);
                    line.Append(' ');

                    writer.WriteLine(line.ToString());
                }

                writer.WriteLine('*');
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nThe data was successfully saved in the file!!!\n");
        }

        public static List<Path> LoadPaths()
        {
            List<Path> paths = new List<Path>();

            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);

                using (reader)
                {
                    string line = reader.ReadLine();
                    paths.Add(new Path());
                    int index = 0;

                    while (line != null)
                    {
                        if (line != "*")
                        {

                            string[] points = line.Split(' ');
                            int x = int.Parse(points[0]);
                            int y = int.Parse(points[1]);
                            int z = int.Parse(points[2]);
                            paths[index].Add(x, y, z);
                        }
                        else
                        {
                            paths.Add(new Path());
                            index++;
                        }

                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Cannot find the file, where the paths are!!!");
            }

            return paths;
        }
    }
}