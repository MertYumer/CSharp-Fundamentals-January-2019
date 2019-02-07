namespace P03_GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public override string ToString()
        {
            return $"{this.Item.GetType().FullName}: {this.Item}".ToString();
        }
    }
}
