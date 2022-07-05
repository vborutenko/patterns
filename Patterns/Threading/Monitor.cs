using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    public static class _Monitor
    {
        static readonly object _object = new object();  

        public static void PrintNumbers()  
        {  
            Monitor.Enter(_object);  
            try  
            {  
                for (int i = 0; i < 5; i++)  
                {  
                    Thread.Sleep(100);  
                    Console.Write(i + ",");  
                }  
                Console.WriteLine();  
            }  
            finally  
            {  
                Monitor.Exit(_object);  
            }  
        }
        

    }

    /// <summary>
    /// Wait,Pulse,PulseAll
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SizeQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        private readonly int maxSize;
        public SizeQueue(int maxSize) { this.maxSize = maxSize; }

        public void Enqueue(T item)
        {
            lock (queue)
            {
                while (queue.Count >= maxSize)
                {
                    Monitor.Wait(queue);
                }
                queue.Enqueue(item);
                if (queue.Count == 1)
                {
                    // wake up any blocked dequeue
                    Monitor.PulseAll(queue);
                }
            }
        }
        public T Dequeue()
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(queue);
                }
                T item = queue.Dequeue();
                if (queue.Count == maxSize - 1)
                {
                    // wake up any blocked enqueue
                    Monitor.PulseAll(queue);
                }
                return item;
            }
        }
    }
}
