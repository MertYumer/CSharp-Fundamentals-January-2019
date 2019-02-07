namespace P03_GenericScale
{
    using System;

    public class EqualityScale<T> where T : IComparable<T>
    {
        public T Left { get; set; }

        public T Right { get; set; }

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public bool AreEqual()
        {
            if (Left.Equals(Right))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
