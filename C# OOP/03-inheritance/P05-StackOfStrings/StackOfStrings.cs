namespace P05_StackOfStrings
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class StackOfStrings : List<string>
    {
        public void Push(string item)
        {
            this.Add(item);
        }

        public string Pop()
        {
            string element = GetLastElement();
            this.RemoveAt(this.Count - 1);
            return element;
        }

        public string Peek()
        {
            return GetLastElement();
        }

        public bool IsEmpty()
        {
            return this.Count < 1;
        }

        private string GetLastElement()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.Last();
        }
    }
}
