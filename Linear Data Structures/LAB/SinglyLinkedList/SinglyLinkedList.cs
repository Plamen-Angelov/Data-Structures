namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Value = item,
                Next = head
            };

            if (Count == 0)
            {
                tail = newNode;
            }

            head = newNode;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            CheckIfListIsEmpty();

            return head.Value;
        }

        public T GetLast()
        {
            CheckIfListIsEmpty();

            return tail.Value;
        }

        public T RemoveFirst()
        {
            CheckIfListIsEmpty();

            Node<T> removed = head;

            head = head.Next;

            if (Count == 1)
            {
                tail = null;
            }

            Count--;
            return removed.Value;
        }

        public T RemoveLast()
        {
            CheckIfListIsEmpty();

            Node<T> removed = tail;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node<T> currentNode = head;

                while (currentNode.Next != tail)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = null;
                tail = currentNode;
            }

            Count--;
            return removed.Value;
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
            => this.GetEnumerator();

        private void CheckIfListIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}