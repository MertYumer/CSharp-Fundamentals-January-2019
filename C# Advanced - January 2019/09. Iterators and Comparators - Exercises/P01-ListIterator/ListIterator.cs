namespace P01_ListIterator
{
    using System;

    public class ListIterator<T>
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
    }
}
