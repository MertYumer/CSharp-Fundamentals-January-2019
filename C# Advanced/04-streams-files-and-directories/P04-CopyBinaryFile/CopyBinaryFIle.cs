namespace P04_CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFIle
    {
        public static void Main()
        {
            var sourceFile = "..//..//..//..//Files//copyMe.png";
            var destinationFile = "..//..//..//..//Files//copyMe-copy.png";

            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                var buffer = new byte[4096];

                using (FileStream writeFile = new FileStream(destinationFile, FileMode.Create))
                {
                    while (true)
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);

                        if (bytesCount == 0)
                        {
                            break;
                        }

                        writeFile.Write(buffer, 0, bytesCount);
                    }
                    
                }
            }
        }
    }
}
