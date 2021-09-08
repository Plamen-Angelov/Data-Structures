using System;
using System.Collections.Generic;

namespace _03.PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                queue.Add(element);
            }
            ;
        }
    }
}
