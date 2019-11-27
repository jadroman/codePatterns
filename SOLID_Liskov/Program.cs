using System;
using System.Linq;

/// <summary>
/// SOLID - Liskov substitution Principle:
/// You should be able to use any derived class instead of a parent class and have it behave in the same manner without modification.
/// Derived class must be substitutable for its base class.
/// </summary>
namespace SOLID_Liskov
{

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            // we are keeping our functionality intact and still having our subclasses act as a substitute to a 
            // base class.

            Calculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");

            Console.WriteLine();

            Calculator evenSum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
        }
    }

    public abstract class Calculator
    {
        protected readonly int[] _numbers;

        public Calculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public abstract int Calculate();
    }

    public class SumCalculator : Calculator
    {
        public SumCalculator(int[] numbers)
        : base(numbers)
        {
        }

        public override int Calculate() => _numbers.Sum();
    }

    public class EvenNumbersSumCalculator : Calculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
        }

        public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
    }

}
