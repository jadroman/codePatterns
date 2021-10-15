using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Queue
    {
        public static void RunExample()
        {
            var myQ = new Queue<int>();
            myQ.Enqueue(1);
            myQ.Enqueue(2);
            myQ.Enqueue(3);
            myQ.Enqueue(4);
            myQ.Enqueue(5);

            foreach (var item in myQ)
            {
                Console.WriteLine(item);
            }

            myQ.Dequeue();

            Console.WriteLine("after dequeue");

            foreach (var item in myQ)
            {
                Console.WriteLine(item);
            }
        }
    }
}
