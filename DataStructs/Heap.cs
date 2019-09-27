using System;
using System.Diagnostics;

namespace DataStructs
{
    public interface IHeap
    {
        int Peek { get; }

        int Pop();
        void Push(int x);
    }

    public class MinHeap : IHeap
    {
        private int[] _heap;
        private int _size;

        public int Peek => _heap[1];

        public MinHeap(int capacity)
        {
            this._heap = new int[capacity + 1];
            this._heap[0] = Int32.MinValue;
            this._size = 0;
        }

        private void Swap(int i, int j)
        {
            int tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private void HeapifyDown(int k)
        {
            int smallest = k;
            int leftIndex = 2 * k;
            int rightIndex = 2 * k + 1;

            if (leftIndex <= _heap.Length && _heap[leftIndex] < _heap[smallest])
            {
                smallest = leftIndex;
            }

            if (rightIndex <= _heap.Length && _heap[rightIndex] < _heap[smallest])
            {
                smallest = rightIndex;
            }

            if (smallest != k)
            {
                Swap(k, smallest);
                HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int k)
        {
            while (_heap[k] < _heap[k / 2])
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void print()
        {
            for (int i = 1; i <= _size / 2; i++)
            {
                string s = string.Format("Parent: {0}, Left child: {1}, Right child: {2}", _heap[i], _heap[i * 2], _heap[i * 2 + 1]);
                Debug.WriteLine(s);
            }
        }

        public void Push(int x)
        {
            _heap[++_size] = x;
            HeapifyUp(_size);
        }

        public int Pop()
        {
            int head = _heap[1];
            _heap[1] = _heap[_size--];
            HeapifyDown(1);

            return head;
        }


    }

    public class MaxHeap : IHeap
    {
        private int[] _heap;
        private int _size;

        public MaxHeap(int capacity)
        {
            this._heap = new int[capacity + 1];
            this._heap[0] = Int32.MaxValue;
            this._size = 0;
        }

        private void Swap(int i, int j)
        {
            int tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private void HeapifyDown(int k)
        {
            int largest = k;
            int leftIndex = 2 * k;
            int rightIndex = 2 * k + 1;

            if (leftIndex <= _heap.Length && _heap[leftIndex] > _heap[largest])
            {
                largest = leftIndex;
            }

            if (rightIndex <= _heap.Length && _heap[rightIndex] > _heap[largest])
            {
                largest = rightIndex;
            }

            if (largest != k)
            {
                Swap(k, largest);
                HeapifyDown(largest);
            }
        }

        private void HeapifyUp(int k)
        {
            while (_heap[k] > _heap[k / 2])
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void print()
        {
            for (int i = 1; i <= _size / 2; i++)
            {
                string s = string.Format("Parent: {0}, Left child: {1}, Right child: {2}", _heap[i], _heap[i * 2], _heap[i * 2 + 1]);
                Debug.WriteLine(s);
            }
        }

        public void Push(int x)
        {
            _heap[++_size] = x;
            HeapifyUp(_size);
        }

        public int Pop()
        {
            int head = _heap[1];
            _heap[1] = _heap[_size--];
            HeapifyDown(1);

            return head;
        }

        public int Peek => _heap[1];

    }
}
