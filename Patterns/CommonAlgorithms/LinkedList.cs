using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithms
{
    public class LinkedList
    {

        public static void Test()
        {
            ListNode listNode0, listNode1 = null, listNode2, listNode3;

            var commonNode = new ListNode(2, new ListNode(4));
            var headA = new ListNode(1, new ListNode(9, new ListNode(1,commonNode)));
            var headB = new ListNode(3, commonNode);
            var listNodeSecond0 = new ListNode(3, commonNode);

            var a = GetIntersectionNode(headA, headB);
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null) return null;
    
            ListNode a = headA;
            ListNode b = headB;
    
            //if a & b have different len, then we will stop the loop after second iteration
            while( a != b){
                //for the end of first iteration, we just reset the pointer to the head of another linkedlist
                a = a == null? headB : a.next;
                b = b == null? headA : b.next;    
            }
    
            return a;
        }

        public ListNode ReverseListIterative(ListNode head)
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

        public ListNode ReverseListRecursion(ListNode head) {
            if (head?.next == null)
                return head;

            ListNode rest = ReverseListRecursion(head.next);
            head.next.next = head;

            head.next = null;
            return rest;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
