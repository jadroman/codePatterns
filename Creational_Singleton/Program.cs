using System;
using static Creational_Singleton.Program;

/// <summary>
/// Creational Singleton pattern:
/// Ensure a class has only one instance and provide a global point of access to it.
///	Prevent multiple instances of the class.
/// Ensuring that all objects access the single instance.
///	Used when we can reuse object instead of creating new ones, eg. Logger Classes, Configuration Classes...
/// </summary>
namespace Creational_Singleton
{

    class Program
    {
        static void Main(string[] args)
        {
            Calculate.Instance.ValueOne = 10.5;
            Calculate.Instance.ValueTwo = 5.5;
            Console.WriteLine("Addition : " + Calculate.Instance.Addition());
            Console.WriteLine("Subtraction : " + Calculate.Instance.Subtraction());
            Console.WriteLine("Multiplication : " + Calculate.Instance.Multiplication());
            Console.WriteLine("Division : " + Calculate.Instance.Division());
            Console.WriteLine("\n----------------------\n");
            Calculate.Instance.ValueTwo = 10.5;
            Console.WriteLine("Addition : " + Calculate.Instance.Addition());
            Console.WriteLine("Subtraction : " + Calculate.Instance.Subtraction());
            Console.WriteLine("Multiplication : " + Calculate.Instance.Multiplication());
            Console.WriteLine("Division : " + Calculate.Instance.Division());
            Console.ReadLine();


        }
    }
    public sealed class Calculate
    {
        /// <summary>
        /// static constructors in C# are specified to execute only when an instance of the class is created 
        /// or a static member is referenced, and to execute only once per AppDomain
        /// </summary>
        private Calculate()
        {
            Console.WriteLine("\n------in constructor-----\n");
        }

        // we are using .NET 'Lazy' class so the object is instantiated the first time it's actually used. Not before that.
        private static readonly Lazy<Calculate> lazy = new Lazy<Calculate>(() => new Calculate());
        public static Calculate Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public double ValueOne { get; set; }
        public double ValueTwo { get; set; }
        public double Addition()
        {
            return ValueOne + ValueTwo;
        }
        public double Subtraction()
        {
            return ValueOne - ValueTwo;
        }
        public double Multiplication()
        {
            return ValueOne * ValueTwo;
        }
        public double Division()
        {
            return ValueOne / ValueTwo;
        }
    }
}
