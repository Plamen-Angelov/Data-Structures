using System;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(6, 
                new Tree<int>(8,
                    new Tree<int>(15, 
                        new Tree<int>(100),
                        new Tree<int>(83),
                        new Tree<int>(61)),
                    new Tree<int>(24,
                        new Tree<int>(115)),
                    new Tree<int>(100,
                        new Tree<int>(102),
                        new Tree<int>(93))));
            tree.RemoveNode(6);
            List<int> list = (List<int>)tree.OrderDfs(); 
            List<int> list2 = (List<int>)tree.OrderBfs();
            Console.WriteLine(list.Count);

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            foreach (var item in list2)
            {
                Console.Write($" .{item} ");
            }
            Console.WriteLine();
        }
    }
}
