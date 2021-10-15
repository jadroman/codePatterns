using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Stack data structure
    ///     LIFO (last in first out)
    ///     usage: 
    ///         undo / redo functionality, 
    ///         word reversal,
    ///         stack back/forward on browsers
    /// </summary>
    class Stack
    {
        public static void RunExample()
        {
            string input = "123";

            var myStack = new Stack<char>();

            Console.WriteLine("Pushing '123' chars to the stack...");
            Console.WriteLine("...now we are reading the stack");

            foreach (var item in input)
            {
                myStack.Push(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine($"item: {item}");
            }

            Console.WriteLine($"myStack.Peek() gives us: {myStack.Peek()}");
            Console.WriteLine("reading the stack after the peek:");
            foreach (var item in myStack)
            {
                Console.WriteLine($"item: {item}");
            }

            myStack.Pop();

            Console.WriteLine("reading the stack after pop");

            foreach (var item in myStack)
            {
                Console.WriteLine($"item: {item}");
            }

            myStack.Push('4');

            Console.WriteLine("reading the stack after push '4'");

            foreach (var item in myStack)
            {
                Console.WriteLine($"item: {item}");
            }
        }
    }
}
