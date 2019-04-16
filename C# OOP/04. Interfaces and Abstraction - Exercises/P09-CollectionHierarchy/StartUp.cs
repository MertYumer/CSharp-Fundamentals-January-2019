namespace P09_CollectionHierarchy
{
    using P09_CollectionHierarchy.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var input = Console.ReadLine().Split();
            int removeOperationsCount = int.Parse(Console.ReadLine());

            foreach(string item in input)
            {
                Console.Write(addCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (string item in input)
            {
                Console.Write(addRemoveCollection.Add(item) + " ");
            }

            Console.WriteLine();

            foreach (string item in input)
            {
                Console.Write(myList.Add(item) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                Console.Write(myList.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
