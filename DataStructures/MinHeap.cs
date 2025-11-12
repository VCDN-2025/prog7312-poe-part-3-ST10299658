using System;
using System.Collections.Generic;

namespace MunicipalServicesApp.DataStructures
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        public int Count
        {
            get { return heap.Count; }
        }

        public void Insert(T item)
        {
            heap.Add(item);
            int i = heap.Count - 1;

            while (i > 0 && heap[(i - 1) / 2].CompareTo(heap[i]) > 0)
            {
                T temp = heap[i];
                heap[i] = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = temp;

                i = (i - 1) / 2;
            }
        }

        public T ExtractMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Heapify(0);

            return min;
        }

        private void Heapify(int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < heap.Count && heap[left].CompareTo(heap[smallest]) < 0)
                smallest = left;

            if (right < heap.Count && heap[right].CompareTo(heap[smallest]) < 0)
                smallest = right;

            if (smallest != i)
            {
                T temp = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = temp;

                Heapify(smallest);
            }
        }

        public T PeekMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");
            return heap[0];
        }
    }
}
