using System;
using System.Diagnostics;

namespace DataStructs
{
    public interface IHeap
    {
        int Peek { get; }
        int Size { get; }

        int Pop();
        void Push(int x);

        void print();
    }

    public class MinHeap : IHeap
    {
        private int[] _heap;
        private int _size;
        private int _capacity;

        private int Parent(int i) { return i / 2; }
        private int Left(int i) { return 2 * i; }
        private int Right(int i) { return ((2 * i) + 1); }

        public int Size => _size;
        public int Peek => _heap[1];

        public MinHeap(int capacity)
        {
            this._heap = new int[capacity + 1];
            this._heap[0] = Int32.MinValue;
            this._size = 0;
            this._capacity = capacity;
        }

        private void Swap(int i, int j)
        {
            int tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private void Heapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int smallest;
            smallest = (left <= _size && _heap[left] <= _heap[i]) ? left : i;

            if (right <= _size && _heap[right] < _heap[smallest]) smallest = right;

            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
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

        public void print()
        {
            for (int i = 1; i <= _size / 2; i++)
            {
                if (((i * 2) + 1) >= _size) continue;
                string s = string.Format("Parent: {0}, Left child: {1}, Right child: {2}", _heap[i], _heap[i * 2], _heap[i * 2 + 1]);
                Debug.WriteLine(s);
            }
        }

        public void Push(int x)
        {
            if (_size >= (_heap.Length - 1)) return;
            _heap[++_size] = x;
            HeapifyUp(_size);
        }

        public int Pop()
        {
            int head = _heap[1];
            _heap[1] = _heap[_size--];
            Heapify(1);

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

        private int Parent(int i) { return i / 2;  }
        private int Left(int i) { return 2 * i; }
        private int Right(int i) { return ((2 * i) + 1); }

        public int Peek => _heap[1];
        public int Size => _size;


        public void Push(int x)
        {
            if (_size >= _heap.Length) return;

            _heap[++_size] = x;
            HeapifyUp(_size);
        }

        public int Pop()
        {
            int head = _heap[1];
            _heap[1] = _heap[_size--];
            Heapify(1);

            return head;
        }
        private void Swap(int i, int j)
        {
            int tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private void Heapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int largest;
            largest = (left <= _size && _heap[left] >= _heap[i]) ? left : i;

            if (right <= _size && _heap[right] > _heap[largest]) largest = right;

            if (largest != i)
            {
                Swap(i, largest);
                Heapify(largest);
            }
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

        public void print()
        {
            for (int i = 1; i <= _size / 2; i++)
            {
                if (((i * 2) + 1) >= _size) continue;

                string s = string.Format("Parent: {0}, Left child: {1}, Right child: {2}", _heap[i], _heap[i * 2], _heap[i * 2 + 1]);
                Debug.WriteLine(s);
            }
        }

    }
}
