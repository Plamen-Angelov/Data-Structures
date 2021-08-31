namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; } = 0;

        public bool Contains(T item)
        {
            bool contains = false;
            Node<T> currentNode = head;

            while (currentNode!= null)
            {
                if (currentNode.Value.Equals(item))
                {
                    contains = true;
                    break;
                }
                currentNode = currentNode.Next;
            }
            return contains;
        }

        public T Dequeue()
        {
            CheckIfQueueIsEmpty();

            Node<T> removed = head;

            head = head.Next;
            Count--;

            return removed.Value;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Value = item,
                Next = null
            };

            if (Count == 0)
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
            }

            tail = newNode;
            Count++;
        }

        public T Peek()
        {
            CheckIfQueueIsEmpty();
            return head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void CheckIfQueueIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
    }
}