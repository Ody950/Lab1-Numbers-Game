


using System;
using System.Reflection;

namespace MathGame
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong." + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }



        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to my game! Let's do some math!");
                Console.WriteLine("Enter a number greater than zero:");
                int size = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[size];
                Populate(numbers);
                int sum = GetSum(numbers);
                int product = GetProduct(numbers, sum);
                int quotient = (int)GetQuotient(product);
                Console.WriteLine($"The numbers in the array are  {string.Join(", ", numbers)}");
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient}  = {quotient}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"You have not enter a number {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"That is a hige number {ex.Message}");
            }
        }



        static void Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter number: {i + 1} of {numbers.Length}");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
        }




        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }



        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Please select a random number between 1 and {numbers.Length}");
            int product = Convert.ToInt32(Console.ReadLine()) - 1;
            try
            {
                return sum * numbers[product];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("The random number (product) is out of range: " + ex.Message);
                throw;
            }
        }


        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by");
            int divisor = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (divisor == 0)
                {
                    Console.WriteLine("Cannot divide by zero.");
                    return 0;
                }

                return decimal.Divide(product, divisor);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero: " + ex.Message);
                return 0;
            }
        }


    }
}

