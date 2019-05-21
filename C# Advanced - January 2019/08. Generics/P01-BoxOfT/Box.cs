namespace P01_BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private Stack<T> items;

        public Box()
        {
            this.items = new Stack<T>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(T item)
        {
            this.items.Push(item);
        }

        public T Remove()
        {
            return this.items.Pop();
        }
    }
}
