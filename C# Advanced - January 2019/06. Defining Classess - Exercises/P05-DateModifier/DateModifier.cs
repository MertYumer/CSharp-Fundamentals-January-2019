namespace P05_DateModifier
{
    using System;

    public class DateModifier
    {
        public double FindDifference(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            return Math.Abs((dateOne - dateTwo).TotalDays);
        }
    }
}
