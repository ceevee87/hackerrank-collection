using System;
using System.Diagnostics;

namespace DataStructs
{
    public class MinHeap : IHeap
    {
        private int[] _heap;
        private int _size;

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


    // this data struct is used to solve the Hackerrank problem 'QHeap'
    // later updated to use in the Hackerrank problem 'Median Update'
    public class QMinHeap : IQHeap
    {
        private int[] _heap;
        private int _size;

        private int Parent(int i) { return i / 2; }
        private int Left(int i) { return 2 * i; }
        private int Right(int i) { return ((2 * i) + 1); }

        public int Size => _size;
        public int Peek => _heap[1];

        public int Get(int n)
        {
            return _heap[n];
        }

        public int WhereIsHeapNotValid()
        {
            for (int ii = 2; ii <= _size; ii++)
            {
                if (!(_heap[Parent(ii)] <= _heap[ii])) return ii;
            }
            return -1;
        }

        public bool isHeapValid()
        {
            for (int ii = 2; ii <= _size; ii++)
            {
                if (!(_heap[Parent(ii)] <= _heap[ii])) return false;
            }
            return true;
        }

        public int[] getSortedHeapEntries()
        {
            int[] result = new int[_size];
            Array.Copy(_heap, 1, result, 0, _size);
            Array.Sort(result);
            return result;
        }

        public QMinHeap(int capacity)
        {
            this._heap = new int[capacity + 1];
            this._heap[0] = Int32.MinValue;
            this._size = 0;
        }

        public void RemoveAt(int x)
        {
            if (x >= (_heap.Length - 1) || x < 1) return;
            if (_size >= (_heap.Length - 1) || _size == 0) return;

            _heap[x] = _heap[_size--];
            if (_heap[x] > _heap[Parent(x)])
            {
                Heapify(x);
            } else
            {
                HeapifyUp(x);
            }
        }

        public int Find(int x)
        {
            for (int ii = 1; ii <= _size; ii++)
            {
                if (_heap[ii] == x) return ii;
            }
            return -1;
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
            smallest = (left <= _size && _heap[left] < _heap[i]) ? left : i;

            if (right <= _size && _heap[right] < _heap[smallest]) smallest = right;

            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }


        private void HeapifyUp(int k)
        {
            while (_heap[k] < _heap[Parent(k)])
            {
                Swap(k, Parent(k));
                k = Parent(k);
            }
        }

        public void Push(int x)
        {
            if (_size >= (_heap.Length - 1)) return;

            int ii = ++_size;
            while (ii > 1 && _heap[Parent(ii)] > x)
            {
                _heap[ii] = _heap[Parent(ii)];
                ii = Parent(ii);
            }
            _heap[ii] = x;

            //_heap[++_size] = x;
            //HeapifyUp(_size);
        }

        public int Pop()
        {
            int head = _heap[1];
            _heap[1] = _heap[_size--];
            Heapify(1);

            return head;
        }

    }

    public class QMaxHeap : IQHeap
    {
        private int[] _heap;
        private int _size;

        private int Parent(int i) { return i / 2; }
        private int Left(int i) { return 2 * i; }
        private int Right(int i) { return ((2 * i) + 1); }
        public int Get(int n)
        {
            return _heap[n];
        }


        public int Size => _size;
        public int Peek => _heap[1];

        public int WhereIsHeapNotValid()
        {
            for (int ii = 2; ii <= _size; ii++)
            {
                if (!(_heap[Parent(ii)] >= _heap[ii])) return ii;
            }
            return -1;
        }

        public bool isHeapValid()
        {
            for (int ii = 2; ii <= _size; ii++)
            {
                if (!(_heap[Parent(ii)] >= _heap[ii])) return false;
            }
            return true;
        }

        public int[] getSortedHeapEntries()
        {
            int[] result = new int[_size];
            Array.Copy(_heap, 1, result, 0, _size);
            Array.Sort(result);
            return result;
        }

        public QMaxHeap(int capacity)
        {
            this._heap = new int[capacity + 1];
            this._heap[0] = Int32.MaxValue;
            this._size = 0;
        }

        public void RemoveAt(int x)
        {
            if (x >= (_heap.Length - 1) || x < 1) return;
            if (_size >= (_heap.Length - 1) || _size == 0) return;

            _heap[x] = _heap[_size--];
            if (_heap[x] < _heap[Parent(x)])
            {
                Heapify(x);
            }
            else
            {
                HeapifyUp(x);
            }

            Heapify(x);
        }

        public int Find(int x)
        {
            for (int ii = 1; ii <= _size; ii++)
            {
                if (_heap[ii] == x) return ii;
            }
            return -1;
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

        private void HeapifyUp(int k)
        {
            while (_heap[k] > _heap[k / 2])
            {
                Swap(k, k / 2);
                k = k / 2;
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
}
