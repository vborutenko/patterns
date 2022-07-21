using System;
using System.Collections.Generic;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            var node0 = new Node(7);
            var node1 = new Node(13);
            var node2 = new Node(11);
            var node3 = new Node(10);
            var node4 = new Node(1);

            node0.next = node1;
            node0.random = null;


            node1.next = node2;
            node1.random = node0;

            node2.next = node3;
            node2.random = node4;

            node3.next = node4;
            node3.random = node2;

            node4.next = null;
            node4.random = node2;

            var result = new Solution().CopyRandomList(node0);

        }
    }


    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            var prevNode = new Node(0);
            var dict = new Dictionary<Node, Node>();
            while (head != null)
            {
                var node = new Node(head.val)
                {
                    random = head.random
                };

                dict.Add(head, node);
                prevNode.next = node;
                prevNode = node;

                head = head.next;
            }

            var newList = prevNode.next;
            var newListCopy = newList;
            while (newListCopy != null)
            {
                if (newListCopy.next != null)
                {
                    newListCopy.random = dict[newListCopy.random];
                }

                newListCopy = newListCopy.next;
            }

            return newList;
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
