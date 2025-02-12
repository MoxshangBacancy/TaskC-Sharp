using System;

namespace Task1
{
    class Program
    {
        public static int CalculateSumOfDigits(int number)
        {
            int sum = 0;
            int temp = Math.Abs(number);

            while (temp != 0)
            {
                sum += temp % 10;
                temp /= 10;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter an integer: ");
                int number = int.Parse(Console.ReadLine());

                int sum = CalculateSumOfDigits(number);

                Console.WriteLine($"The sum of the digits of {number} is: {sum}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too large! Please enter a smaller integer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
