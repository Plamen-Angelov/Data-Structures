namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; } = 0;

        public bool Contains(T item)
        {
            Node<T> current = top;
            bool contains = false;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    contains = true;
                    break;
                }
                current = current.Previous;
            }

            return contains;
        }

        public T Peek()
        {
            CheckIfStackIsEmpty();
            return top.Value;
        }

        public T Pop()
        {
            CheckIfStackIsEmpty();
            Node<T> removed = top;
            top = top.Previous;
            removed.Previous = null;

            Count--;
            return removed.Value;
        }


        public void Push(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = item;
            newNode.Previous = top;
            top = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = top;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        private void CheckIfStackIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
    }
}