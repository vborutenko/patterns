using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    /// <summary>
    /// Thread is a lower-level concept: if you're directly starting a thread, you know it will be a separate thread,
    /// rather than executing on the thread pool etc.
    ///
    /// Task is more than just an abstraction of "where to run some code" though -
    /// it's really just "the promise of a result in the future". So as some different examples:
    /// </summary>
    public static class TaskParallelLibrary
    {
        public static void Test()
        {

            ParallelClass.Test();

            Thread.CurrentThread.Name = "Main";




        }
    }

    public static class ParallelClass
    {
        public static void Test()
        {
            //Parallel.Invoke executes an array of Action delegates in parallel, and then waits for them to complete
            //
            //On the surface, this seems like a convenient shortcut for creating and waiting on two Task objects.
            //But there’s an important difference: Parallel.Invoke still works efficiently if you pass in an array of a
            //million delegates. This is because it partitions large numbers of elements into batches which it assigns to
            //a handful of underlying Tasks — rather than creating a separate Task for each delegate.
            Parallel.Invoke(
                () => new WebClient().DownloadFile("http://www.linqpad.net", "lp.html"),
                () => new WebClient().DownloadFile("http://www.jaoo.dk", "jaoo.html"));


            //As with Parallel.Invoke, we can feed Parallel.For and Parallel.ForEach a large number of work items
            //and they’ll be efficiently partitioned onto a few tasks.

            Parallel.For(0, 100, Foo);

            Parallel.ForEach("Hello, world", Foo);
        }

        public static void Foo(char i)
        {
            Thread.Sleep(1000);
        }

        public static void Foo(int i)
        {
            Thread.Sleep(1000);
        }
    }
}
