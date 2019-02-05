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
            list.Insert(1, 8);
            list.RemoveAt(2);
            list.Swap(0, 2);
            Console.WriteLine(list.Contains(9));

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
