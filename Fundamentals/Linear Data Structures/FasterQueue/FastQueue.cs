namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this.head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            T oldHead = head.Item;
            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                //var headItem = this._head.Item;
                //var newHead = this.head.Next;
                //this._head.Next = null;
                this.head = head.Next;
            }
            this.Count--;

            return oldHead;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = null
            };

            if (this.head is null)
            {
                this.head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}