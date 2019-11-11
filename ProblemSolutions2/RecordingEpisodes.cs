using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions2
{
    public class Episode
    {
        private int _startTime;
        private int _endTime;
        private int _id;

        public int StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public int EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public Episode(int at, int ol, int id)
        {
            _startTime = at;
            _endTime = ol;
            _id = id;
        }
    }

    public class RecordingEpisodes
    {


        #region EpisodeCollection

        public class EpisodeCollection
        {
            private Episode[] _heap;
            private int _size;

            private int Parent(int i) { return i / 2; }
            private int Left(int i) { return 2 * i; }
            private int Right(int i) { return ((2 * i) + 1); }


            public int Size => _size;
            public Episode Peek => _heap[1];

            public EpisodeCollection(int capacity)
            {
                this._heap = new Episode[capacity + 1];
                this._heap[0] = new Episode(int.MinValue, int.MinValue, 0);
                this._size = 0;
            }

            private int Compare(int a, int b)
            {
                if (_heap[a].EndTime < _heap[b].EndTime) return -1;
                if (_heap[a].EndTime == _heap[b].EndTime) return 0;
                return 1;
            }

            private void Swap(int i, int j)
            {
                Episode tmp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = tmp;
            }

            private void HeapifyDown(int i)
            {
                int left = Left(i);
                int right = Right(i);
                int smallest;
                smallest = (left <= _size && Compare(left, i) <= 0) ? left : i;

                if (right <= _size && Compare(right, smallest) < 0) smallest = right;

                if (smallest != i)
                {
                    Swap(i, smallest);
                    HeapifyDown(smallest);
                }
            }


            private void HeapifyUp(int k)
            {
                while (Compare(k, Parent(k)) < 0)
                {
                    Swap(k, Parent(k));
                    k = Parent(k);
                }
            }

            public void Push(Episode x)
            {
                if (_size >= (_heap.Length - 1)) return;
                _heap[++_size] = x;
                HeapifyUp(_size);
            }

            public Episode Pop()
            {
                Episode head = _heap[1];
                _heap[1] = _heap[_size--];
                HeapifyDown(1);

                return head;
            }
        }
        #endregion

    }
}
