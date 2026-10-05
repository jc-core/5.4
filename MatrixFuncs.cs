namespace Assignment5_4 {
    internal class MatrixFuncs {

        public static int DiagonalSum(int[,] grid) {

            int size = grid.GetLength(0);
            int total = 0;

            for (int row = 0; row < size; row++)
                total += grid[row, row];

            return total;

        }

        public static void ShowGrid(int[,] grid) {

            int size = grid.GetLength(0);

            for (int row = 0; row < size; row++) {

                for (int column = 0; column < size; column++)
                    Console.Write($"{grid[row, column],5}");

                Console.WriteLine();

            }

        }
    }
}
