namespace P05_GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Box<T> where T : IComparable<T>
    {
        public Box(List<T> items)
        {
            Items = items;
        }

        public List<T> Items { get; set; }

        public int GetGreaterElement(T element)
        {
            int counter = 0;

            foreach (var item in Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
