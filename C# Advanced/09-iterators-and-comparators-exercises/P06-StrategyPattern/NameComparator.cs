namespace P06_StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length.CompareTo(y.Name.Length) != 0)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }

            return x.Name.ToLower().CompareTo(y.Name.ToLower());
        }
    }
}
