namespace Assignment5_4 {
    internal class Program {

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Show Digits");
                Console.WriteLine("  2 - Diagonal Sum");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        ShowDigits();
                        break;
                    case '2':
                        DiagonalSum();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void ShowDigits() {

            Console.WriteLine();

            int number = ReadInt("Enter a positive whole number:", false);

            Console.Write("Digits: ");
            DigitFuncs.ShowDigits(number);
            Console.WriteLine();

        }

        static void DiagonalSum() {

            Console.WriteLine();
            Console.WriteLine("The diagonal runs from the top left corner to the bottom right.");

            int[,] grid = ReadGrid();

            Console.WriteLine();
            MatrixFuncs.ShowGrid(grid);
            Console.WriteLine();
            Console.WriteLine($"Diagonal total: {MatrixFuncs.DiagonalSum(grid)}");

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int ReadInt(string prompt, bool allowNegative) {

            while (true) {

                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int value) && (value >= 0 || allowNegative))
                    return value;

                Console.WriteLine(allowNegative ? "Only whole numbers are allowed." : "Only positive whole numbers or 0 are allowed.");

            }

        }

        static int[,] ReadGrid() {

            int size;

            while (true) {

                Console.Write("Grid size: ");

                if (int.TryParse(Console.ReadLine(), out size) && size >= 1 && size <= 10)
                    break;

                Console.WriteLine("Whole numbers from 1 to 10 only, try again.");

            }

            int[,] grid = new int[size, size];

            for (int row = 0; row < size; row++) {

                while (true) {

                    Console.Write($"Row {row + 1}, {size} numbers separated by spaces: ");
                    string[] numInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (numInputs.Length != size) {
                        Console.WriteLine($"Each row needs exactly {size} numbers, try again.");
                        continue;
                    }

                    bool parsed = true;

                    for (int column = 0; column < size; column++) {
                        if (!int.TryParse(numInputs[column], out int value)) {
                            parsed = false;
                            break;
                        }
                        grid[row, column] = value;
                    }

                    if (parsed)
                        break;

                    Console.WriteLine("Whole numbers only, with a space between each one.");

                }

            }

            return grid;

        }
    }
}
