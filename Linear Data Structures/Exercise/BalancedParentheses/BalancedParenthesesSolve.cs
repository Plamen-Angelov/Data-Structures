namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            bool balanced = true;

            if (parentheses.Length % 2 != 0
                || string.IsNullOrEmpty(parentheses)
                || string.IsNullOrWhiteSpace(parentheses))
            {
                return false;
            }

            while (parentheses.Length != 0)
            {
                if (parentheses[0] == '('
                || parentheses[0] == '{'
                || parentheses[0] == '[')
                {
                    stack.Push(parentheses[0]);
                    parentheses = parentheses.Remove(0, 1);
                }
                else if ((parentheses[0] == ')'
                    || parentheses[0] == '}'
                    || parentheses[0] == ']')
                    && stack.Count == 0)
                {
                    balanced = false;
                    break;
                }
                else if (stack.Peek() == '(' && parentheses[0] == ')'
                    || stack.Peek() == '{' && parentheses[0] == '}'
                    || stack.Peek() == '[' && parentheses[0] == ']')
                {
                    stack.Pop();
                    parentheses = parentheses.Remove(0, 1);
                }
                else
                {
                    balanced = false;
                    break;
                }
            }
            return balanced;
        }
    }
}
