namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int capacity = 4;

        public int Count { get; private set; } = 0;


        public ReversedList()
            : this(DefaultCapacity) 
        {
        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
            this.capacity = capacity;
        }

        public T this[int index]
        {
            get
            {
                CheckIfIndexIsValid(index);
                return items[Count - index - 1];
            }
            set
            {
                CheckIfIndexIsValid(index);
                items[index] = value;
            }
        }


        public void Add(T item)
        {
            if (Count == items.Length)
            {
                items = DoubleArraySize();
            }

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (var it in items)
            {
                if (it.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = Count -1; i >= 0; i--)
            {
                if (items[i].Equals(item))
                {
                    return Count - i - 1;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (Count == items.Length)
            {
                items = DoubleArraySize();
            }

            CheckIfIndexIsValid(index);

            for (int i = Count; i > Count - index; i--)
            {
                items[i] = items[i - 1];
            }

            items[Count - index] = item;
            
            Count++;
        }

        public bool Remove(T item)
        {
            int index = Count -1;
            bool isFound = false;

            foreach (var it in items)
            {
                if (it.Equals(item))
                {
                    isFound = true;
                    break;
                }
                index--;
            }

            if (isFound)
            {
                for (int i = index; i < Count; i++)
                {
                    items[i] = items[i + 1];
                }
                items[Count - 1] = default(T);
                Count--;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIfIndexIsValid(index);

            for (int i = Count - index - 1; i < Count - 1; i++)
            {
                items[i] = items[index + 1];
            }
            items[Count - 1] = default(T);
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIfIndexIsValid(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private T[] DoubleArraySize()
        {
            T[] newItems = new T[items.Length * 2];
            
            Array.Copy(items, newItems, Count);
            return newItems;
        }
    }
}