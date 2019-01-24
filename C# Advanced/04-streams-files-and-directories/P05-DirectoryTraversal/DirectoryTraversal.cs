namespace P05_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            var directoryInfo = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles("..//..//..//", "*.*", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);

                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var fileSize = Decimal.Divide(file.Length, 1024);

                if (!directoryInfo.ContainsKey(extension))
                {
                    directoryInfo.Add(extension, new Dictionary<string, decimal>());
                }

                if (!directoryInfo[extension].ContainsKey(fullName))
                {
                    directoryInfo[extension].Add(fullName, fileSize);
                }
            }
            string destinationPath = "..//..//..//..//Files//report.txt";

            using (StreamWriter streamWriter = new StreamWriter(destinationPath))
            {
                var orderedInfo = directoryInfo
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key);

                foreach (var currentFile in orderedInfo)
                {
                    streamWriter.WriteLine(currentFile.Key);

                    var orderedFiles = currentFile.Value
                        .OrderBy(f => f.Value);

                    foreach (var fileInfo in orderedFiles)
                    {
                        streamWriter.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:f3}kb");
                    }
                }
            }
        }
    }
}
