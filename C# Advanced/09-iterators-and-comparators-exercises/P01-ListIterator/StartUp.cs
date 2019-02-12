namespace P01_ListIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var collection = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            ListIterator<string> list = new ListIterator<string>(collection);

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "Print":
                        list.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "END":
                        return;
                }
            }
        }
    }
}
