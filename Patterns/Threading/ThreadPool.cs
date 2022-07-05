using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    /// <summary>
    /// Whenever you start a thread, a few hundred microseconds are spent organizing such things
    /// as a fresh private local variable stack.
    /// Each thread also consumes (by default) around 1 MB of memory.
    /// The thread pool cuts these overheads by sharing and recycling threads,
    /// allowing multithreading to be applied at a very granular level without a performance penalty.
    /// There are a number of ways to enter the thread pool:

    ///Via the Task Parallel Library (from Framework 4.0)
    ///    By calling ThreadPool.QueueUserWorkItem
    ///    Via asynchronous delegates
    ///    Via BackgroundWorker
    /// </summary>
    public static class _ThreadPool
    {
        public static void Test()
        {
            //Entering the Thread Pool Without TPL
            ThreadPool.QueueUserWorkItem(Go);

            //Entering the Thread Pool Without TPL
            Task.Run(() => Go("abc"));
        }

        static void Go (object data)   // data will be null with the first call.
        {
            Console.WriteLine ("Hello from the thread pool! " + data);
        }
    }
}
