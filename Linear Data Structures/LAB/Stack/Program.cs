using System;

namespace Problem02.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(34);
            stack.Push(12);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());


        }
    }
}
