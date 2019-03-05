namespace P04_RandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var list = new RandomList();
            list.Add("dog");
            list.Add("cat");
            list.Add("cow");
            Console.WriteLine(list.RandomString());
        }
    }
}
