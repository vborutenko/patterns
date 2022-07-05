using System;
using System.Threading;

namespace Threading
{
    public static class _Interlocked
    {
        static int _value;
        public static void Test()
        {
            Thread thread1 = new Thread(A);
            Thread thread2 = new Thread(A);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(_value);

        }

        static void A()
        {
            // Add one then subtract two.
            Interlocked.Increment(ref _value);
            Interlocked.Decrement(ref _value);
            Interlocked.Decrement(ref _value);
            //Interlocked.Exchange()
        }
    }
}
