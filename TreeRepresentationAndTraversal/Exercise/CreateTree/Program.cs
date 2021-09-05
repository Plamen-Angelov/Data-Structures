using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[]
           {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
           };

            TreeFactory tree = new TreeFactory();
            Tree<int> root = tree.CreateTreeFromStrings(input);
            Console.WriteLine(root.GetAsString());
            Console.WriteLine(string.Join(' ', root.GetLeafKeys()));
        }
    }
}
