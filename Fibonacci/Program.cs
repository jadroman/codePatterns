using System;

namespace Fibonacci
{
    class Program
    {
        /// <summary>
        /// Next number is the sum of previous two numbers for example 0, 1, 1, 2, 3, 5, 8, 13, 21 etc
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 1, num3, numOfElements, counter;
            Console.WriteLine("How much elements?");
            numOfElements = Convert.ToInt32(Console.ReadLine());
            Console.Write($"{num1}, {num2}");

            for (counter = 2; counter < numOfElements; counter++)
            {
                num3 = num1 + num2;
                Console.Write($", {num3}");
                num1 = num2;
                num2 = num3;
            }
        }
    }
}
