namespace P03_JediGalaxy
{
    public class Board
    {
        private int[,] matrix;

        public Board(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];
            this.InitializeMаtrix();
        }

        public int[,] Matrix
        {
            get => this.matrix;
            set => this.matrix = value;
        }

        private void InitializeMаtrix()
        {
            int value = 0;

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < this.matrix.GetLength(0) && col >= 0 && col < this.matrix.GetLength(1);
        }
    }
}
