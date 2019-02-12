namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> customStack;

        public CustomStack()
        {
            this.customStack = new List<T>();
        }

        public void Push(List<T> elements)
        {
            this.customStack.AddRange(elements);
        }

        public void Pop()
        {
            if (this.customStack.Count == 0)
            {
                Console.WriteLine("No elements");
            }

            else
            {
                this.customStack.RemoveAt(this.customStack.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.customStack.Count - 1; i >= 0; i--)
            {
                yield return this.customStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
