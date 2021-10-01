using System;

namespace StringManipulation
{
    class Program
    {
        /// <summary>
        /// https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("write string to reverse:");
            string input = Console.ReadLine();

            //Console.WriteLine(Reverse(input));
            Console.WriteLine(ReverseString.ReverseStringDirect(input));
        }
    }
}
