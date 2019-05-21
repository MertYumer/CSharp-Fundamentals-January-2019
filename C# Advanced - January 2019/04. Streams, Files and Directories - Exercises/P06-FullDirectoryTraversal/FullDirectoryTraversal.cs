namespace P06_FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            var directoryInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!directoryInfo.ContainsKey(extension))
                {
                    directoryInfo.Add(extension, new List<FileInfo>());
                }

                directoryInfo[extension].Add(fileInfo);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            using (StreamWriter writer = new StreamWriter(pathToDesktop))
            {
                var orderedInfo = directoryInfo
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key);

                foreach (var kvp in orderedInfo)
                {
                    var extension = kvp.Key;
                    var info = kvp.Value;

                    writer.WriteLine(extension);

                    var orderedFiles = info
                        .OrderBy(f => f.Length);

                    foreach (var fileInfo in orderedFiles)
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;
                        writer.WriteLine($"--{name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
