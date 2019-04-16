namespace P02_Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListIterator<T> : IEnumerable<T>
    {
        private T[] elements;
        private int index;

        public ListIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index < this.elements.Length - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.elements.Length == 0)
            {
                Console.WriteLine("Invalid operation");
            }

            else
            {
                Console.WriteLine(this.elements[index]);
            }
        }

        public bool HasNext()
        {
            return this.index < this.elements.Length - 1
                ? true
                : false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
