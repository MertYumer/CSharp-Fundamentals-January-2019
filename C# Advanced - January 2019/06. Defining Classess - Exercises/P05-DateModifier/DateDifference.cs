namespace P05_DateModifier
{
    using System;

    public class DateDifference
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var diff = new DateModifier();

            Console.WriteLine(diff.FindDifference(firstDate, secondDate));
        }
    }
}
