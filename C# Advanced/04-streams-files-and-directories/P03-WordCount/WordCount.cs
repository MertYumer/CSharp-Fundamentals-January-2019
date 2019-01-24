namespace P03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            var sourceFile = "..//..//..//..//Files//words.txt";
            var destinationPath = "..//..//..//..//Files//actualResult.txt";

            var dictionary = new Dictionary<string, int>();

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                while (true)
                {
                    var word = streamReader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    else if (!dictionary.ContainsKey(word))
                    {
                        dictionary.Add(word, 0);
                    }
                }
            }

            sourceFile = "..//..//..//..//Files//text.txt";

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                {
                    while (true)
                    {
                        var line = streamReader.ReadLine();

                        if (line == null)
                        {
                            var orderedWords = dictionary.OrderByDescending(w => w.Value);

                            foreach (var word in orderedWords)
                            {
                                streamWriter.WriteLine($"{word.Key} - {word.Value}");
                            }

                            return;
                        }

                        var words = line
                            .Split(new char[] { ',', '.', '?', '!', '-', ' ' }, 
                            StringSplitOptions.RemoveEmptyEntries);

                        foreach (var word in words)
                        {
                            if (dictionary.ContainsKey(word.ToLower()))
                            {
                                dictionary[word.ToLower()]++;
                            }
                        }
                    }
                }
            }
        }
    }
}
