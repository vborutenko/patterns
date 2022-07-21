using System;
using CommonAlgorithms.Sorting;

namespace CommonAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort.Test();
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, current = head, next = null;
            while (current != null) 
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            return prev;

        }
    }
}
