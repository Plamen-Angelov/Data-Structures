using System;
using System.Collections.Generic;

namespace _02.MaxHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var integerHeap = new MaxHeap<int>();
            var elements = new List<int>() { 5, 6, 9, 15, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }
        }
    }
}
