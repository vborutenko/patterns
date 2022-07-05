using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    /// <summary>
    /// C# semaphore allows only a limited number of threads to enter into a critical section.
    /// Semaphore is mainly used in scenarios where we have limited number of resources
    /// and we have to limit the number of threads that can use it.
    /// </summary>
    public static class SemaphoreAndSemaphoreSlim
    {
        public static void Test()
        {
            Semaphore semaphoreObject = new Semaphore(initialCount: 3, maximumCount: 3, name: "PrinterApp");
            Printer printerObject = new Printer();
 
            for (int i = 0; i < 20; ++i)
            {
                int j = i;
                Task.Factory.StartNew(() =>
                {
                    semaphoreObject.WaitOne();
                    printerObject.Print(j);
                    semaphoreObject.Release();
                });
            }
            Console.ReadLine();
        }


    }

    class Printer
    {
        public void Print(int documentToPrint)
        {
            Console.WriteLine("Printing document: " + documentToPrint);
            //code to print document
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }


    /// <summary>
    /// The SemaphoreSlim class represents a lightweight, fast semaphore that can be used for waiting within
    /// a single process when wait times are expected to be very short.
    /// </summary>
    public static class SemaphoreSlim
    {

    }
}
