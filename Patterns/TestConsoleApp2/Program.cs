using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace TestConsoleApp2
{
    internal class Program
    {


        public static void Main(string[] args)
        {

            Console.WriteLine(color.blue);

        }


    }

    public enum color
    { red, green, blue };

    public class A
    {
        public int I { get; set; }

        public A(int i)
        {
            this.I = i;
        }
    }

    public class B : A
    {
        public B(int i) : base(i)
        {
        }
    }


    //public class Solution {
    //    public ListNode SortList(ListNode head) {
        
    //    }
    //}


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

