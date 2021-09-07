using System;

namespace _01.BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(18,
                new BinaryTree<int>(23,
                    new BinaryTree<int>(16,
                        new BinaryTree<int>(19, null, null),
                        new BinaryTree<int>(20, null, null)),
                    new BinaryTree<int>(14, null, null)),
                new BinaryTree<int>(40,
                    new BinaryTree<int>(8, null, null),
                    new BinaryTree<int>(17,
                        new BinaryTree<int>(30, null, null),
                        new BinaryTree<int>(40, null, null))));

            Console.WriteLine(tree.AsIndentedPreOrder(0));
            //foreach (var item in tree.PreOrder())
            //{
            //    Console.WriteLine(item.Value);
            //}

            //Console.WriteLine();
            //Console.WriteLine();

            foreach (var item in tree.InOrder())
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
