namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>
            {
                Value = item,
                Next = this.head,
                Previous = null
            };

            if (Count == 0)
            {
                tail = newNode;
            }
            else
            {
                head.Previous = newNode;
            }

            this.head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Value = item,
                Next = null,
                Previous = tail
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
            else
            {
                head.Previous = null;
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
                tail = tail.Previous;
                tail.Next = null;
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
            => GetEnumerator();

        private void CheckIfListIsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}