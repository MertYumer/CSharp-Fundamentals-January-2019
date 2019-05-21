namespace P01_Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;

        private int[] data;
        private int index;

        public Database(params int[] values)
        {
            CheckLength(values);
            this.data = new int[16];
            this.index = 0;
            CopyArray(values);
        }

        private void CopyArray(int[] values)
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        private void CheckLength(int[] values)
        {
            if (values.Length > 16)
            {
                throw new InvalidOperationException("The size of the " +
                    "parameter must be equal or less than 16!");
            }
        }

        public void Add(int value)
        {
            if (this.index == Capacity)
            {
                throw new InvalidOperationException("Data is full!");
            }

            this.data[this.index] = value;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Data is empty!");
            }

            this.data[this.index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.index).ToArray();
        }
    }
}
