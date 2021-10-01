using System;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write string to reverse:");
            string input = Console.ReadLine();

            //Console.WriteLine(Reverse(input));
            Console.WriteLine(ReverseString.ReverseStringDirect(input));
        }
    }
}
