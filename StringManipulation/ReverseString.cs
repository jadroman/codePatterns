using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class ReverseString
    {

        public static string Reverse(string input)
        {
            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);
            return new string(inputArray);
        }

        public static string ReverseStringDirect(string input)
        {
            char[] reversed = new char[input.Length];
            int revIndex = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed[revIndex++] = input[i];
            }

            return new string(reversed);
        }
    }
}
