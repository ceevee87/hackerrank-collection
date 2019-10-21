﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructs;

namespace HackerRankCollection.ProblemSolutions
{
    public static class FindTheRunningMedian
    {
        public static double[] runningMedian(int[] a)
        {
            if (a.Length == 1)
            {
                return new double[] { Math.Round((double)a[0], 1) };
            }
            if (a.Length == 2)
            {
                double[] result = new double[2];
                result[0] = Math.Round((double)a[0], 1);
                result[1] = Math.Round((double)((a[0] + a[1]) / 2.0), 1);
                return result;
            }

            return CalcRunningMedian(a);
        }

        private static double[] CalcRunningMedian(int[] a)
        {
            // length of a should be at least 3.
            // we need to double check this .. do that later

            IHeap minHeap = new MinHeap(a.Length);
            IHeap maxHeap = new MaxHeap(a.Length);

            double[] result = new double[a.Length];
            result[0] = Math.Round((double)a[0], 1) + 0.0;
            result[1] = Math.Round((double)((a[0] + a[1]) / 2.0), 1);

            double runningMedian = result[1];

            // setup the max and min heaps
            if (a[0] > a[1])
            {
                minHeap.Push(a[0]);
                maxHeap.Push(a[1]);
            }
            else
            {
                minHeap.Push(a[1]);
                maxHeap.Push(a[0]);
            }

            for (int ii = 2; ii < a.Length; ii++)
            {
                double nextval = Math.Round((double)a[ii], 1);
                if (nextval <= runningMedian)
                {
                    maxHeap.Push(a[ii]);
                }
                else
                {
                    minHeap.Push(a[ii]);
                }
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
                if (minHeap.Size == maxHeap.Size)
                {
                    runningMedian = Math.Round((double)(minHeap.Peek + maxHeap.Peek) / 2.0, 1);
                }
                else
                {
                    // one heap is larger than the other (by 1 element only). The median value
                    // is at the top of the heavy heap.
                    runningMedian = (maxHeap.Size > minHeap.Size) ? Math.Round((double)maxHeap.Peek, 1) : Math.Round((double)minHeap.Peek, 1);
                }
                result[ii] = runningMedian;
            }
            return result;
        }
        static void MainXXX(string[] args)
        {
            // this is required for submission to hacker rank because
            // they need formatting on the output to handle the single decimal 
            // place even when a medium result is "12.0" or "1.0".
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int aCount = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[aCount];

            for (int aItr = 0; aItr < aCount; aItr++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[aItr] = aItem;
            }

            double[] result = runningMedian(a);

            // get all the double values and convert them to strings with a single decimal point.
            string[] res3 = result.Select(v => String.Format("{0:#.0}", v)).ToArray();

            textWriter.WriteLine(string.Join("\n", res3));
            textWriter.Flush();
            textWriter.Close();
        }

    }
}