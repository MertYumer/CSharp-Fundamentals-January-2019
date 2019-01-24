namespace P01_EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        public static void Main()
        {
            var sourceFile = "..//..//..//..//Files//text.txt";

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                var line = streamReader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        var lineWords = line
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Reverse()
                            .ToArray();

                        for (int i = 0; i < lineWords.Length; i++)
                        {
                            var currentWord = lineWords[i].ToCharArray();

                            for (int j = 0; j < currentWord.Length; j++)
                            {
                                switch (currentWord[j])
                                {
                                    case '-':
                                        currentWord[j] = '@';
                                        break;

                                    case ',':
                                        currentWord[j] = '@';
                                        break;

                                    case '.':
                                        currentWord[j] = '@';
                                        break;

                                    case '!':
                                        currentWord[j] = '@';
                                        break;

                                    case '?':
                                        currentWord[j] = '@';
                                        break;
                                }
                            }

                            lineWords[i] = new string(currentWord);
                        }

                        Console.WriteLine(string.Join(" ", lineWords));
                    }
                    
                    line = streamReader.ReadLine();
                    counter++;
                }
            }
        }
    }
}
