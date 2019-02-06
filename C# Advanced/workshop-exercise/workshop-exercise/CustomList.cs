namespace workshop_exercise
{
    using System;

    public class CustomList
    {
        private object[] items;
        private int capacity;

        public CustomList()
        {
            this.items = new object[0];
            this.Count = 0;
        }

        public object[] Items
        {
            get { return this.GetElements(); }
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        private void Resize()
        {
            this.Capacity = this.items.Length * 2 == 0
                ? 4
                : this.items.Length * 2;

            object[] tempArray = new object[this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private object[] GetElements()
        {
            object[] tempArray = new object[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            return tempArray;
        }

        public void Add(object item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public object RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            object item = this.items[index];
            this.items[index] = default(object);
            this.Shift(index);
            this.Count--;
            this.items[this.Count] = null;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            object[] secondArray = new object[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                secondArray[i] = this.items[i];
            }

            this.items = secondArray;
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count ||
                secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            object tempItem = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempItem;
        }
    }
}
