using System;
using System.Collections.Generic;

namespace Problem04.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedParenthesesSolve balanced = new BalancedParenthesesSolve();
            string text = Console.ReadLine();
            Console.WriteLine(balanced.AreBalanced(text));
        }
    }
}
