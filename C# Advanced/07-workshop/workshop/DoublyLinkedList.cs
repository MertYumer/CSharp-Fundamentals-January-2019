namespace workshop
{
    using System;

    public class DoublyLinkedList
    {
        private class ListNode
        {
            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }

            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }

            else
            {
                var newTail = new ListNode(element);
                this.tail.PreviousNode = newTail;
                newTail.NextNode = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public int RemovеFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }

            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public int RemovеLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }

            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] elements = new int[this.Count];

            var currentNode = this.head;

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return elements;
        }
    }
}
