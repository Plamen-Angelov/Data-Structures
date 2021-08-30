namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
            items = new T[DEFAULT_CAPACITY];
        }

        public List(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIfIndexIsValid(index);
                return items[index];
            }
            set
            {
                CheckIfIndexIsValid(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; } = 0;

        public void Add(T item)
        {
            if (items.Length == Count)
            {
                items = DoubleArraySize();
            }

            items[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    index = i;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            CheckIfIndexIsValid(index);

            if (items.Length == Count)
            {
                items = DoubleArraySize();
            }

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

       

        public T Get(int index)
        {
            CheckIfIndexIsValid(index);

            return items[index];
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    RemoveAt(i);
                    isRemoved = true;
                }
            }
            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            CheckIfIndexIsValid(index);

            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[Count - 1] = default;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;

            while (index != Count)
            {
                yield return items[index];
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


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

            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            return newItems;
        }
    }
}