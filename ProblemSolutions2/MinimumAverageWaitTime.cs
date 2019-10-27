using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCollection.ProblemSolutions2
{
    public class Customer
    {
        private long _arrivalTime;
        private long _orderLength;

        public long ArrivalTime { get => _arrivalTime; set => _arrivalTime = value; }
        public long OrderLength { get => _orderLength; set => _orderLength = value; }

        public Customer(long at, long ol)
        {
            _arrivalTime = at;
            _orderLength = ol;
        }
    }

    public static class MinimumAverageWaitTime
    {
        public enum HeapType { ByArrivalTime, ByOrderLength };

        #region CustomerCollection

        public class CustomerCollection
        {
            private Customer[] _heap;
            private int _size;
            private HeapType _orderBy;

            private int Parent(int i) { return i / 2; }
            private int Left(int i) { return 2 * i; }
            private int Right(int i) { return ((2 * i) + 1); }


            public int Size => _size;
            public Customer Peek => _heap[1];

            public CustomerCollection(int capacity, HeapType ht)
            {
                this._heap = new Customer[capacity + 1];
                this._heap[0] = new Customer(long.MinValue, long.MinValue);
                this._size = 0;
                this._orderBy = ht;
            }

            private int Compare(int a, int b)
            {
                if (_orderBy == HeapType.ByArrivalTime)
                {
                    if (_heap[a].ArrivalTime < _heap[b].ArrivalTime) return -1;
                    if (_heap[a].ArrivalTime == _heap[b].ArrivalTime) return 0;
                    return 1;
                }

                if (_orderBy == HeapType.ByOrderLength)
                {
                    if (_heap[a].OrderLength < _heap[b].OrderLength) return -1;
                    if (_heap[a].OrderLength == _heap[b].OrderLength) return 0;
                    return 1;
                }

                // error condition
                return Int32.MinValue;
            }

            private void Swap(int i, int j)
            {
                Customer tmp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = tmp;
            }

            private void HeapifyDown(int i)
            {
                int left = Left(i);
                int right = Right(i);
                int smallest;
                smallest = (left <= _size && Compare(left,i) <= 0) ? left : i;

                if (right <= _size && Compare(right, smallest) < 0) smallest = right;

                if (smallest != i)
                {
                    Swap(i, smallest);
                    HeapifyDown(smallest);
                }
            }


            private void HeapifyUp(int k)
            {
                while (Compare(k,Parent(k)) < 0)
                {
                    Swap(k, Parent(k));
                    k = Parent(k);
                }
            }

            public void Push(Customer x)
            {
                if (_size >= (_heap.Length - 1)) return;
                _heap[++_size] = x;
                HeapifyUp(_size);
            }

            public Customer Pop()
            {
                Customer head = _heap[1];
                _heap[1] = _heap[_size--];
                HeapifyDown(1);

                return head;
            }
        }
        #endregion

        private static CustomerCollection InitCustomerCollection(int[][] aCustomers, HeapType heaptype)
        {
            CustomerCollection result = new CustomerCollection(aCustomers.Length, heaptype);

            for (int ii = 0; ii < aCustomers.Length; ii++)
            {
                result.Push(new Customer(aCustomers[ii][0], aCustomers[ii][1]));
            }
            return result;
        }

        /*
         * create a min heap of all customers based on their arrival time. 
         * then using a second min-heap, based on cook time, 
         * keep track of the people who are currently in 
         * the pizza shop (i.e.whose arrival time < the total time elapsed) 
         * process the people in the order determined by the 2nd min heap.
         */
        public static long minimumAverage(int[][] aCustomers)
        {
            int numCustomers = aCustomers.Length;

            CustomerCollection custsByArrivalTime = InitCustomerCollection(aCustomers, HeapType.ByArrivalTime);
            CustomerCollection custsByOrderLength = new CustomerCollection(aCustomers.Length, HeapType.ByOrderLength);

            long  waitTimeTotal = 0;
            long totalTimeElapsed = custsByArrivalTime.Peek.ArrivalTime;
            while (custsByArrivalTime.Size > 0 || custsByOrderLength.Size > 0)
            {
                // this handles the disjoint case where N customers come into 
                // the store all at exclusive times during the day (none of the customers
                // see each other in the restaurant)
                if (custsByOrderLength.Size == 0 && custsByArrivalTime.Size > 0)
                {
                    custsByOrderLength.Push(custsByArrivalTime.Pop());
                }

                Customer currentCustomer = custsByOrderLength.Pop();

                totalTimeElapsed += currentCustomer.OrderLength;
                waitTimeTotal += (totalTimeElapsed - currentCustomer.ArrivalTime);

                // get all customers who arrive while the current customer's 
                // order is being prepared (customer arrival time + order length)

                // all customers who are in the restaurant at the same time are ordered by
                // the length of their food order. always pick orders that have the
                // shortest prep time. 
                while (custsByArrivalTime.Size > 0 && custsByArrivalTime.Peek.ArrivalTime <= totalTimeElapsed)
                {
                    custsByOrderLength.Push(custsByArrivalTime.Pop());
                }

            }
            return waitTimeTotal / numCustomers;
        }
    }
}
