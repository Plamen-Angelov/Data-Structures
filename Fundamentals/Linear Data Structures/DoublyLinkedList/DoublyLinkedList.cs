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
            Node<T> node = new Node<T>();

            if (Count == 0)
            {
                head = node;
                tail = node;
                node.Next = null;
                node.Previous = null;
            }
            else
            {
                head.Previous = node;
                node.Next = head;
                node.Previous = null;
                head = node;
            }

            node.Item = item;
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> node = new Node<T>();

            if (Count == 0)
            {
                head = node;
                tail = node;
                node.Next = null;
                node.Previous = null;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                node.Next = null;
                tail = node;
            }

            node.Item = item;
            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Collection is empty.");
            }
            else
            {
                return head.Item;
            }
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Collection is empty.");
            }
            else
            {
                return tail.Item;
            }
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Collection is empty.");
            }
            else
            {
                Node<T> removed = head;
                head.Next.Previous = null;
                head = head.Next;

                Count--;
                return removed.Item;
            }
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Collection is empty.");
            }
            else
            {
                Node<T> removed = tail;
                tail.Previous.Next = null;
                tail = tail.Previous;

                Count--;
                return tail.Item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}