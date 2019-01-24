namespace P02_LineNumbers
{
    using System;
    using System.Linq;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            var sourceFile = "..//..//..//..//Files//text.txt";
            var destinationPath = "..//..//..//..//Files//output.txt";

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                {
                    var line = streamReader.ReadLine();
                    int counter = 1;
                    int punctuationMarksCount = 0;
                    int lettersCount = 0;

                    while (line != null)
                    {
                        foreach (var symbol in line)
                        {
                            if (char.IsPunctuation(symbol))
                            {
                                punctuationMarksCount++;
                            }

                            else if (char.IsLetter(symbol))
                            {
                                lettersCount++;
                            }
                        }

                        streamWriter.WriteLine($"Line {counter++}: " +
                            $"{line} ({lettersCount})({punctuationMarksCount})");

                        line = streamReader.ReadLine();
                        punctuationMarksCount = 0;
                        lettersCount = 0;
                    }
                }
            }
        }
    }
}
