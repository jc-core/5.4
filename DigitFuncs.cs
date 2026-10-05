namespace Assignment5_4 {
    internal class DigitFuncs {

        public static void ShowDigits(int number) {

            if (number < 10) {
                Console.Write($"{number} ");
                return;
            }

            ShowDigits(number / 10);
            Console.Write($"{number % 10} ");

        }
    }
}
