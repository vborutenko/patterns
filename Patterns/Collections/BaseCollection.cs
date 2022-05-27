using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public static class BaseCollection
    {
        public static void Test()
        {
            IEnumerable<int> enumerable = new List<int>() { 1, 2, 3, 4, 5 };

            foreach(var item in enumerable)
            {
                // process items
            }

            //ICollection <T>  add count and add,remove,clear

            ICollection<int> collection = new List<int>() { 1, 2, 3, 4, 5 };
 
            var count = collection.Count;
            collection.Add(6);
            collection.Remove(2);
            collection.Clear();

            //IList <T> add access and insert by index

            IList<int> list = new List<int> { 1, 2, 3, 4, 5 };
 
            var item2 = list[2]; // item = 3
            list[2] = 6;        // list = { 1, 2, 6, 4, 5 }


            //hash set - set of unique elements

            ISet<int> set = new HashSet<int> { 1, 2, 3, 4, 5 }; 
            var added = set.Add(0);


            // queue FIFO (first in, first out) 

            var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
 
            queue.Enqueue(6);
            var dequeuedItem = queue.Dequeue();

            var peekedItem = queue.Peek(); // leave elem in collection

            //Stack -  LIFO (last in, first out) 
        }
    }
}
