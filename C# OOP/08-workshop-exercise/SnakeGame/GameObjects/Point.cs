namespace SnakeGame.GameObjects
{
    using System;

    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return this.leftX;
            }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                this.leftX = value;
            }
        }

        public int TopY
        {
            get
            {
                return this.topY;
            }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                this.topY = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.WriteLine(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine(symbol);
        }
    }
}
