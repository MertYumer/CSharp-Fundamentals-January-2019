namespace workshop_exercise
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var list = new CustomList();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Insert(3, 8);
            list.RemoveAt(1);
            list.Swap(0, 2);
            Console.WriteLine(list.Contains(7));
        }
    }
}
