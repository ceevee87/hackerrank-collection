using DataStructs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions2
{
    // this problem is rated Hard and worth 70 points on Hacker Rank
    public static class MedianUpdates
    {
        internal class MedianTracker
        {
            private IQHeap minHeap;
            private IQHeap maxHeap;

            private bool atLeastOneHeapEmpty = true;
            private bool bothHeapsEmpty = true;

            public MedianTracker(int n)
            {
                minHeap = new QMinHeap(2 + n / 2);
                maxHeap = new QMaxHeap(2 + n / 2);
            }

            public bool RemoveArg(int val)
            {
                if (bothHeapsEmpty)
                {
                    return false;
                }

                double runningMedian = Convert.ToDouble(getCurrentMedian());
                int loc = -1;

                if (val == runningMedian)
                {
                    loc = maxHeap.Find(val);
                    if (loc < 0)
                    {
                        loc = minHeap.Find(val);
                        if (loc > 0)
                        {
                            minHeap.RemoveAt(loc);
                        }
                    }
                    else
                    {
                        maxHeap.RemoveAt(loc);
                    }

                }
                else if (val < runningMedian)
                {
                    loc = maxHeap.Find(val);
                    if (loc > 0)
                    {
                        maxHeap.RemoveAt(loc);
                    }
                }
                else
                {
                    loc = minHeap.Find(val);
                    if (loc > 0)
                    {
                        minHeap.RemoveAt(loc);
                    }
                }

                BalanceHeaps();

                atLeastOneHeapEmpty = (minHeap.Size == 0 || maxHeap.Size == 0);
                bothHeapsEmpty = (minHeap.Size == 0 && maxHeap.Size == 0);
                if (loc > 0) return true;
                return false;
            }

            public void AddArg(int a)
            {
                // if both heaps are empty then always
                // add this to the max heap. we'll fix it
                // when the 2nd item is added.

                if (bothHeapsEmpty)
                {
                    maxHeap.Push(a);
                    bothHeapsEmpty = false;
                    return;
                }

                if (atLeastOneHeapEmpty)
                {
                    if (maxHeap.Size > 0)
                    {
                        atLeastOneHeapEmpty = false;
                        if (a < maxHeap.Peek)
                        {
                            minHeap.Push(maxHeap.Pop());
                            maxHeap.Push(a);
                            bothHeapsEmpty = false;
                            return;
                        }
                        else
                        {
                            minHeap.Push(a);
                            return;
                        }
                    }

                    if (minHeap.Size > 0)
                    {
                        atLeastOneHeapEmpty = false;
                        if (a > minHeap.Peek)
                        {
                            maxHeap.Push(minHeap.Pop());
                            minHeap.Push(a);
                            bothHeapsEmpty = false;
                            return;
                        }
                        else
                        {
                            maxHeap.Push(a);
                            return;
                        }
                    }
                }

                double runningMedian = Convert.ToDouble(getCurrentMedian());
                if (a <= runningMedian)
                {
                    maxHeap.Push(a);
                }
                else
                {
                    minHeap.Push(a);
                }
                BalanceHeaps();
            }

            public string getCurrentMedian()
            {
                if (bothHeapsEmpty)
                {
                    return "Wrong!";
                }

                if (atLeastOneHeapEmpty)
                {
                    if (maxHeap.Size > 0) return maxHeap.Peek.ToString();
                    return minHeap.Peek.ToString();
                }

                if (minHeap.Size == maxHeap.Size)
                {
                    long v = (long)minHeap.Peek + (long)maxHeap.Peek;
                    double v2 = Math.Round((double)v / 2.0, 1);
                    return v2.ToString();
                }

                // one heap is larger than the other (by 1 element only). The median value
                // is at the top of the heavy heap.
                double runningMedian = (maxHeap.Size > minHeap.Size) ? Math.Round((double)maxHeap.Peek, 1) : Math.Round((double)minHeap.Peek, 1);
                return runningMedian.ToString();

            }

            private void BalanceHeaps()
            {
                // we need to keep the max heap sizes balanced within
                // a size of 1 of each other
                if (Math.Abs(minHeap.Size - maxHeap.Size) > 1)
                {
                    if (minHeap.Size > maxHeap.Size)
                    {
                        maxHeap.Push(minHeap.Pop());
                    }
                    else
                    {
                        minHeap.Push(maxHeap.Pop());
                    }
                    // now they are the same size
                }
            }
        }

        #region solution

        private static string ProcessHeapCommand(string heapCmd, int heapArg, MedianTracker medianTracker)
        {
            if (heapCmd.Equals("r"))
            {
                if (!medianTracker.RemoveArg(heapArg)) return "Wrong!";
            }
            if (heapCmd.Equals("a"))
            {
                medianTracker.AddArg(heapArg);
            }
            return medianTracker.getCurrentMedian();
        }

        private static string[] ProcessHeapCommands(string[] heapCmd, int[] heapArg, MedianTracker medianTracker)
        {
            string[] res = new string[heapCmd.Length];
            for (int ii = 0; ii < heapCmd.Length; ii++)
            {
                res[ii] = ProcessHeapCommand(heapCmd[ii], heapArg[ii], medianTracker);
            }
            return res;
        }

        public static string[] medianTest(string[] a, int[] x)
        {
            MedianTracker medianTracker = new MedianTracker(a.Length);

            return ProcessHeapCommands(a, x, medianTracker);
        }

        public static void median(string[] a, int[] x)
            {
                MedianTracker medianTracker = new MedianTracker(a.Length);

                string[] res = ProcessHeapCommands(a, x, medianTracker);

                for (int ii = 0; ii < a.Length; ii++)
                {
                    Debug.WriteLine(res[ii]);
                }
            }
            #endregion
        }
    }
