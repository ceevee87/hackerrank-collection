using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankCollection.ProblemSolutions2
{
    public class RecordingEpisodes
    {
        #region episode
        public class Episode
        {
            private int _startTime;
            private int _endTime;
            private int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

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
        #endregion

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
                //if (_heap[a].Id < _heap[b].Id) return -1;
                //if (_heap[a].Id == _heap[b].Id) return 0;

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


        #region solution
        /*
         * Complete the episodeRecording function below.
         */
        public static int[] EpisodeRecording(int[][] episodes)
        {

            EpisodeCollection heapo = new EpisodeCollection(episodes.Length * 2 + 1);

            int episodeIdCounter = 1;
            for (int ii = 0; ii < episodes.Length; ii++)
            {
                heapo.Push(new Episode(episodes[ii][0], episodes[ii][1], episodeIdCounter));
                heapo.Push(new Episode(episodes[ii][2], episodes[ii][3], episodeIdCounter));
                episodeIdCounter++;
            }

            List<Episode> res = new List<Episode>();
            HashSet<int> episodeIds = new HashSet<int>();

            Debug.WriteLine(string.Format("Number of heap entries: {0}", heapo.Size));

            while (heapo.Size >= 0)
            {
                Episode curEp = heapo.Pop();
                res.Add(curEp);
                episodeIds.Add(curEp.Id);

                while (heapo.Size >= 0)
                {
                    Episode x = heapo.Peek;
                    if (x.StartTime <= curEp.EndTime || episodeIds.Contains(x.Id))
                    {
                        heapo.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int L;
            int R;

            if (res.Count == 1)
            {
                return new int[2] { res.ElementAt(0).Id, res.ElementAt(0).Id };
            }

            if (res.Count > 1)
            {
                L = res.ElementAt(0).Id;
                R = res.ElementAt(0).Id;

                int l = L;
                int r = R;
                for (int ii = 1; ii < res.Count; ii++)
                {
                    if (res.ElementAt(ii).Id - 1 == r)
                    {
                        r++;
                    }
                    else
                    {
                        if ((r - l) > R - L)
                        {
                            R = r;
                            L = l;
                        }
                        l = res.ElementAt(ii).Id;
                        r = l;
                    }
                }
                if ((r - l) > R - L)
                {
                    R = r;
                    L = l;
                }
                return new int[2] { L, R };
            }
            return new int[2] { -1, -1 };
        }
        #endregion
    }
}
