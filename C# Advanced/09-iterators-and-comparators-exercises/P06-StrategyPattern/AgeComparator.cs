namespace P06_StrategyPattern
{
    using System.Collections.Generic;

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
