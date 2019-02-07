namespace P03_GenericScale
{
    using System;

    public class Scale<T> where T : IComparable<T>
    {
        public T Left { get; set; }

        public T Right { get; set; }

        public Scale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public T GetHeavier()
        {
            if (Left.Equals(Right))
            {
                return default(T);
            }

            else if (Left.CompareTo(Right) > 0)
            {
                return Left;
            }

            else
            {
                return Right;
            }
        }
    }
}
