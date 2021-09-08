namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public int Size => heap.Count;

        public T Dequeue()
        {
            VerifyIsNotEmpty();
            T top = heap[0];
            heap[0] = heap[Size - 1];
            heap.RemoveAt(Size -1);

            HeapifyDown(0);

            return top;
        }

        public void HeapifyDown(int index)
        {
            if (index == 0) return;

            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= Size) return;

            if (rightChildIndex < Size && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = temp;
                HeapifyDown(maxChildIndex);
            }
        }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(Size - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0) return;

            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                Heapify(parentIndex);
            }
        }

        public T Peek()
        {
            VerifyIsNotEmpty();
            return heap[0];
        }

        private void VerifyIsNotEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
        }
    }
}
